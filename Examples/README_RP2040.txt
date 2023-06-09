Hardware and configuration for Adafruit Feather RP2040:
;------------------------------------------------------------------------------
  Refer to https://learn.adafruit.com/adafruit-feather-rp2040-pico

  Don't attach serial adapter until board has loaded uf2 file (see instructions below):
  Connect serial adapter (e.g. USB to TTL Serial Cable - Debug / Console Cable for Raspberry Pi) to USART1:
     * Green TX to RX Pin 14
     * White RX to TX Pin15
     * Black GND to GND Pin 4 
     * Red Power disconnected as it is 5V
     I used a LiPo battery for power after reading this note from Adafruit:
     It is not recommended, but technically possible: Connect an external 5V power supply to the USB and GND pins. Not recommended, this may cause unexpected behavior when plugging in the USB port because you will be back-powering the USB port, which could confuse or damage your computer.
     (https://learn.adafruit.com/adafruit-feather-rp2040-pico/power-management)

  Use the USB method to install .uf2
  1. Use a USB C cable to connect to the Feather board.
  2. Press and hold BOOT/SEL button (by QWIC connector)
  3. Press and release Reset button (by USB connector)
  4. Release BOOT/SEL button
  5. Board will appear as USB drive (mine appears as RPI-RP2)
  6. Drag and drop mecrisp-stellaris-pico-with-tools.uf2 to USB drive
  7. Board will disconnect and reboot
  8. Disconnect USB C cable!
  9. Connect Serial Adapter from above
  10. ls /dev/cu* to find specific serial port being used (mine was /dev/cu.usbserial-0001)
  11. Connect with picocom (or your favorite serial app):
  picocom -b 115200 /dev/cu.usbserial-0001 --imap lfcrlf,crcrlf --omap delbs,crlf

;------------------------------------------------------------------------------
