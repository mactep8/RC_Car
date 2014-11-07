#define IRQ_interrupt 0
uint8_t ItStatus1, ItStatus2;
//uint32_t tx_start = 0;

void rfm22_readBuffer()
{
  RF_Mode = Receive;
  spiSendAddress(0x7f); // Send the package read command
  for (int16_t i = 0; i < 21; i++) {
    tx_buf[i] = spiReadData();
//      Serial.print(rx_buf[i]); Serial.print(" ");
  }
//    Serial.println("received");
}

void rfm22_need_reboot()
{
  if (spiReadRegister(0x0C) == 0) {     // detect the locked module and reboot
//    Serial.println("module locked?");
    init_rfm(0);
    rx_reset();
  }
}

void rfm_start()
{
  setupRfmInterrupt();
  sei();
  delay(50);
  init_rfm(0);
  rfmSetChannel(1);
  rx_reset();
}

void setupRfmInterrupt()
{
  attachInterrupt(IRQ_interrupt, RFM22B_Int, FALLING);
}

void RFM22B_Int()
{
  #ifdef DEBUG
//  Serial.print("RF_Mode="); Serial.println(RF_Mode);
  #endif

  if (RF_Mode == Transmit) {
    RF_Mode = Transmitted;
  }

  if (RF_Mode == Receive) {
    RF_Mode = Received;
  }
}

void init_rfm(uint8_t isbind)
{
  ItStatus1 = spiReadRegister(0x03);   // read status, clear interrupt
  ItStatus2 = spiReadRegister(0x04);
  spiWriteRegister(0x06, 0x00);    // disable interrupts
  spiWriteRegister(0x07, RF22B_PWRSTATE_READY); // disable lbd, wakeup timer, use internal 32768,xton = 1; in ready mode
  spiWriteRegister(0x09, 0x7f);   // c = 12.5p
  spiWriteRegister(0x0a, 0x05);
  spiWriteRegister(0x0b, 0x12);    // gpio0 TX State
  spiWriteRegister(0x0c, 0x15);    // gpio1 RX State
  spiWriteRegister(0x0d, 0xfd);    // gpio 2 micro-controller clk output
  spiWriteRegister(0x0e, 0x00);    // gpio    0, 1,2 NO OTHER FUNCTION.

  setModemRegs(&modem_params[2]);

  // Packet settings
  spiWriteRegister(0x30, 0x8c);    // enable packet handler, msb first, enable crc,
  spiWriteRegister(0x32, 0x0f);    // no broadcast, check header bytes 3,2,1,0
  spiWriteRegister(0x33, 0x42);    // 4 byte header, 2 byte synch, variable pkt size
  spiWriteRegister(0x34, 0x0a);    // 10 nibbles (40 bit preamble)
  spiWriteRegister(0x35, 0x2a);    // preath = 5 (20bits), rssioff = 2
  spiWriteRegister(0x36, 0x2d);    // synchronize word 3
  spiWriteRegister(0x37, 0xd4);    // synchronize word 2
  spiWriteRegister(0x38, 0x00);    // synch word 1 (not used)
  spiWriteRegister(0x39, 0x00);    // synch word 0 (not used)

  for (uint8_t i = 0; i < 4; i++) {
    spiWriteRegister(0x3a + i, rf_magic[i]);   // tx header
    spiWriteRegister(0x3f + i, rf_magic[i]);   // rx header
  }

  spiWriteRegister(0x43, 0xff);    // all the bit to be checked
  spiWriteRegister(0x44, 0xff);    // all the bit to be checked
  spiWriteRegister(0x45, 0xff);    // all the bit to be checked
  spiWriteRegister(0x46, 0xff);    // all the bit to be checked

  spiWriteRegister(0x6d, DEFAULT_RF_POWER);

  spiWriteRegister(0x79, 0);

  spiWriteRegister(0x7a, DEFAULT_CHANNEL_SPACING);   // channel spacing

  spiWriteRegister(0x73, 0x00);
  spiWriteRegister(0x74, 0x00);    // no offset

  rfmSetCarrierFrequency(DEFAULT_CARRIER_FREQUENCY);

}

void rfmSetChannel(uint8_t ch)
{
//  uint8_t magicLSB = (bind_data.rf_magic & 0xff) ^ ch;
  spiWriteRegister(0x79, ch);
//  spiWriteRegister(0x3a + 3, magicLSB);
//  spiWriteRegister(0x3f + 3, magicLSB);
  #ifdef DEBUG
//  Serial.print("current channel =");Serial.println(ch);
  #endif
}

uint8_t rfmGetRSSI(void)
{
  return spiReadRegister(0x26);
}

void rx_reset(void)
{
  spiWriteRegister(0x07, RF22B_PWRSTATE_READY);
  spiWriteRegister(0x7e, 36);    // threshold for rx almost full, interrupt when 1 byte received
  spiWriteRegister(0x08, 0x03);    //clear fifo disable multi packet
  spiWriteRegister(0x08, 0x00);    // clear fifo, disable multi packet
  spiWriteRegister(0x07, RF22B_PWRSTATE_RX);   // to rx mode
  spiWriteRegister(0x05, RF22B_Rx_packet_received_interrupt);
  ItStatus1 = spiReadRegister(0x03);   //read the Interrupt Status1 register
  ItStatus2 = spiReadRegister(0x04);
}

void setModemRegs(struct rfm22_modem_regs* r)
{

  spiWriteRegister(0x1c, r->r_1c);
  spiWriteRegister(0x1d, r->r_1d);
  spiWriteRegister(0x1e, r->r_1e);
  spiWriteRegister(0x20, r->r_20);
  spiWriteRegister(0x21, r->r_21);
  spiWriteRegister(0x22, r->r_22);
  spiWriteRegister(0x23, r->r_23);
  spiWriteRegister(0x24, r->r_24);
  spiWriteRegister(0x25, r->r_25);
  spiWriteRegister(0x2a, r->r_2a);
  spiWriteRegister(0x6e, r->r_6e);
  spiWriteRegister(0x6f, r->r_6f);
  spiWriteRegister(0x70, r->r_70);
  spiWriteRegister(0x71, r->r_71);
  spiWriteRegister(0x72, r->r_72);
}

void rfmSetCarrierFrequency(uint32_t f)
{
  uint16_t fb, fc, hbsel;
  if (f < 480000000) {
    hbsel = 0;
    fb = f / 10000000 - 24;
    fc = (f - (fb + 24) * 10000000) * 4 / 625;
  } else {
    hbsel = 1;
    fb = f / 20000000 - 24;
    fc = (f - (fb + 24) * 20000000) * 2 / 625;
  }
  spiWriteRegister(0x75, 0x40 + (hbsel ? 0x20 : 0) + (fb & 0x1f));
  spiWriteRegister(0x76, (fc >> 8));
  spiWriteRegister(0x77, (fc & 0xff));
}

void watchdogReset()
{
  __asm__ __volatile__ ( "wdr\n" );
}

uint32_t getInterval()
{
  uint32_t ret;
  // Sending a x byte packet on bps y takes about (emperical)
  // usec = (x + 15) * 8200000 / baudrate
#define BYTES_AT_BAUD_TO_USEC(bytes, bps) ((uint32_t)((bytes) + 15) * 8200000L / (uint32_t)(bps))

  ret = (BYTES_AT_BAUD_TO_USEC(21, modem_params[2].bps) + 2000);

  ret += (BYTES_AT_BAUD_TO_USEC(21, modem_params[2].bps) + 1000);

  // round up to ms
  ret = ((ret + 999) / 1000) * 1000;

  // enable following to limit packet rate to 50Hz at most

  return ret;
}

void tx_packet_async(uint8_t* pkt, uint8_t size)
{
//  spiWriteRegister(0x07, RF22B_PWRSTATE_READY);
//  delay(50);
  spiWriteRegister(0x3e, size);   // total tx size

  for (uint8_t i = 0; i < size; i++) {
    spiWriteRegister(0x7f, pkt[i]);
  }

  spiWriteRegister(0x05, RF22B_PACKET_SENT_INTERRUPT);
  ItStatus1 = spiReadRegister(0x03);      //read the Interrupt Status1 register
  ItStatus2 = spiReadRegister(0x04);
//  tx_start = micros();
  spiWriteRegister(0x07, RF22B_PWRSTATE_TX);    // to tx mode

  RF_Mode = Transmit;
}

