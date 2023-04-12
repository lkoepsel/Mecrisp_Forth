\             Section 2.3.1.7
$d0000000 constant SIO_BASE               \ SIO registers
SIO_BASE $000 + constant SIO_CPUID            \ Processor core identifer
SIO_BASE $004 + constant SIO_GPIO_IN          \ Input value for GPIO pins
SIO_BASE $008 + constant SIO_GPIO_HI_IN       \ Input value for QSPI pins
SIO_BASE $010 + constant SIO_GPIO_OUT         \ GPIO output value
SIO_BASE $014 + constant SIO_GPIO_OUT_SET     \ GPIO output value set
SIO_BASE $018 + constant SIO_GPIO_OUT_CLR     \ GPIO output value clear
SIO_BASE $01c + constant SIO_GPIO_OUT_XOR     \ GPIO output value XOR
SIO_BASE $020 + constant SIO_GPIO_OE          \ GPIO output enable
SIO_BASE $024 + constant SIO_GPIO_OE_SET      \ GPIO output enable set
SIO_BASE $028 + constant SIO_GPIO_OE_CLR      \ GPIO output enable clear
SIO_BASE $02c + constant SIO_GPIO_OE_XOR      \ GPIO output enable XOR
SIO_BASE $030 + constant SIO_GPIO_HI_OUT      \ QSPI output value
SIO_BASE $034 + constant SIO_GPIO_HI_OUT_SET  \ QSPI output value set
SIO_BASE $038 + constant SIO_GPIO_HI_OUT_CLR  \ QSPI output value clear
SIO_BASE $03c + constant SIO_GPIO_HI_OUT_XOR  \ QSPI output value XOR
SIO_BASE $040 + constant SIO_GPIO_HI_OE       \ QSPI output enable
SIO_BASE $044 + constant SIO_GPIO_HI_OE_SET   \ QSPI output enable set
SIO_BASE $048 + constant SIO_GPIO_HI_OE_CLR   \ QSPI output enable clear
SIO_BASE $04c + constant SIO_GPIO_HI_OE_XOR   \ QSPI output enable XOR
                                          \ Don't need any more right now?

\             Section 2.14.3
$4000c000 constant RESETS_BASE              \ Reset control register
RESETS_BASE $0 + constant RESETS_RESET      \ Reset control      Section 2.14.3 for list
RESETS_BASE $4 + constant RESETS_WDSEL      \ Watchdog select
RESETS_BASE $8 + constant RESETS_RESET_DONE \ Reset done

\             Section 2.19.6
$40014000 constant IO_BANK0_BASE           \ GPIO Base defined IO_BANK0_BASE in SDK
                                           \ GPIO Status and Control Registers
IO_BANK0_BASE $000 + constant IO_BANK0_GPIO0_STATUS
IO_BANK0_BASE $004 + constant IO_BANK0_GPIO0_CTRL
IO_BANK0_BASE $008 + constant IO_BANK0_GPIO1_STATUS
IO_BANK0_BASE $00c + constant IO_BANK0_GPIO1_CTRL
IO_BANK0_BASE $010 + constant IO_BANK0_GPIO2_STATUS
IO_BANK0_BASE $014 + constant IO_BANK0_GPIO2_CTRL
IO_BANK0_BASE $018 + constant IO_BANK0_GPIO3_STATUS
IO_BANK0_BASE $01c + constant IO_BANK0_GPIO3_CTRL
IO_BANK0_BASE $020 + constant IO_BANK0_GPIO4_STATUS
IO_BANK0_BASE $024 + constant IO_BANK0_GPIO4_CTRL
IO_BANK0_BASE $028 + constant IO_BANK0_GPIO5_STATUS
IO_BANK0_BASE $02c + constant IO_BANK0_GPIO5_CTRL
IO_BANK0_BASE $030 + constant IO_BANK0_GPIO6_STATUS
IO_BANK0_BASE $034 + constant IO_BANK0_GPIO6_CTRL
IO_BANK0_BASE $038 + constant IO_BANK0_GPIO7_STATUS
IO_BANK0_BASE $03c + constant IO_BANK0_GPIO7_CTRL
IO_BANK0_BASE $040 + constant IO_BANK0_GPIO8_STATUS
IO_BANK0_BASE $044 + constant IO_BANK0_GPIO8_CTRL
IO_BANK0_BASE $048 + constant IO_BANK0_GPIO9_STATUS
IO_BANK0_BASE $04c + constant IO_BANK0_GPIO9_CTRL
IO_BANK0_BASE $050 + constant IO_BANK0_GPIO10_STATUS
IO_BANK0_BASE $054 + constant IO_BANK0_GPIO10_CTRL
IO_BANK0_BASE $058 + constant IO_BANK0_GPIO11_STATUS
IO_BANK0_BASE $05c + constant IO_BANK0_GPIO11_CTRL
IO_BANK0_BASE $060 + constant IO_BANK0_GPIO12_STATUS
IO_BANK0_BASE $064 + constant IO_BANK0_GPIO12_CTRL
IO_BANK0_BASE $068 + constant IO_BANK0_GPIO13_STATUS
IO_BANK0_BASE $06c + constant IO_BANK0_GPIO13_CTRL
IO_BANK0_BASE $070 + constant IO_BANK0_GPIO14_STATUS
IO_BANK0_BASE $074 + constant IO_BANK0_GPIO14_CTRL
IO_BANK0_BASE $078 + constant IO_BANK0_GPIO15_STATUS
IO_BANK0_BASE $07c + constant IO_BANK0_GPIO15_CTRL
IO_BANK0_BASE $080 + constant IO_BANK0_GPIO16_STATUS
IO_BANK0_BASE $084 + constant IO_BANK0_GPIO16_CTRL
IO_BANK0_BASE $088 + constant IO_BANK0_GPIO17_STATUS
IO_BANK0_BASE $08c + constant IO_BANK0_GPIO17_CTRL
IO_BANK0_BASE $090 + constant IO_BANK0_GPIO18_STATUS
IO_BANK0_BASE $094 + constant IO_BANK0_GPIO18_CTRL
IO_BANK0_BASE $098 + constant IO_BANK0_GPIO19_STATUS
IO_BANK0_BASE $09c + constant IO_BANK0_GPIO19_CTRL
IO_BANK0_BASE $0a0 + constant IO_BANK0_GPIO20_STATUS
IO_BANK0_BASE $0a4 + constant IO_BANK0_GPIO20_CTRL
IO_BANK0_BASE $0a8 + constant IO_BANK0_GPIO21_STATUS
IO_BANK0_BASE $0ac + constant IO_BANK0_GPIO21_CTRL
IO_BANK0_BASE $0b0 + constant IO_BANK0_GPIO22_STATUS
IO_BANK0_BASE $0b4 + constant IO_BANK0_GPIO22_CTRL
IO_BANK0_BASE $0b8 + constant IO_BANK0_GPIO23_STATUS
IO_BANK0_BASE $0bc + constant IO_BANK0_GPIO23_CTRL
IO_BANK0_BASE $0c0 + constant IO_BANK0_GPIO24_STATUS
IO_BANK0_BASE $0c4 + constant IO_BANK0_GPIO24_CTRL
IO_BANK0_BASE $0c8 + constant IO_BANK0_GPIO25_STATUS
IO_BANK0_BASE $0cc + constant IO_BANK0_GPIO25_CTRL
IO_BANK0_BASE $0d0 + constant IO_BANK0_GPIO26_STATUS
IO_BANK0_BASE $0d4 + constant IO_BANK0_GPIO26_CTRL
IO_BANK0_BASE $0d8 + constant IO_BANK0_GPIO27_STATUS
IO_BANK0_BASE $0dc + constant IO_BANK0_GPIO27_CTRL
IO_BANK0_BASE $0e0 + constant IO_BANK0_GPIO28_STATUS
IO_BANK0_BASE $0e4 + constant IO_BANK0_GPIO28_CTRL
IO_BANK0_BASE $0e8 + constant IO_BANK0_GPIO29_STATUS
IO_BANK0_BASE $0ec + constant IO_BANK0_GPIO29_CTRL

\             Section 4.4.4
$4003C000 constant SPI0_BASE               \ SPI0 base defined SPI0_BASE in SDK
$40040000 constant SPI1_BASE               \ SPI1 base defined SPI1_BASE in SDK

SPI0_BASE $000 + constant SPI0_SSPCR0      \ Control register 0
SPI1_BASE $000 + constant SPI1_SSPCR0      \ $000F for 16-bit $0007 for 8-bit
SPI0_BASE $004 + constant SPI0_SSPCR1      \ Control register 1
SPI1_BASE $004 + constant SPI1_SSPCR1      \ $0 to disable $2 to enable
SPI0_BASE $008 + constant SPI0_SSPDR       \ Data register
SPI1_BASE $008 + constant SPI1_SSPDR      
SPI0_BASE $00c + constant SPI0_SSPSR       \ Status register
SPI1_BASE $00c + constant SPI1_SSPSR      
SPI0_BASE $010 + constant SPI0_SSPCPSR     \ Clock prescale register
SPI1_BASE $010 + constant SPI1_SSPCPSR     \ Normally set to 2  
SPI0_BASE $014 + constant SPI0_SSPIMSC     \ Interrupt mask set/clear register
SPI1_BASE $014 + constant SPI1_SSPIMSC      
SPI0_BASE $018 + constant SPI0_SSPRIS      \ Raw interrupt status register
SPI1_BASE $018 + constant SPI1_SSPRIS     
SPI0_BASE $01c + constant SPI0_SSPMIS      \ Masked interrupt status register
SPI1_BASE $01c + constant SPI1_SSPMIS      
SPI0_BASE $020 + constant SPI0_SSPICR      \ Interrupt clear register
SPI1_BASE $020 + constant SPI1_SSPICR      
SPI0_BASE $024 + constant SPI0_SSPDMACR    \ DMA control register
SPI1_BASE $024 + constant SPI1_SSPDMACR      
SPI0_BASE $fe0 + constant SPI0_SSPPERIPHID0     \ Peripheral ID registers
SPI1_BASE $fe0 + constant SPI1_SSPPERIPHID0
SPI0_BASE $fe4 + constant SPI0_SSPPERIPHID1
SPI1_BASE $fe4 + constant SPI1_SSPPERIPHID1
SPI0_BASE $fe8 + constant SPI0_SSPPERIPHID2
SPI1_BASE $fe8 + constant SPI1_SSPPERIPHID2
SPI0_BASE $feC + constant SPI0_SSPPERIPHID3
SPI1_BASE $feC + constant SPI1_SSPPERIPHID3
SPI0_BASE $ff0 + constant SPI0_SSPPCELLID0     \ Primecell ID registers
SPI1_BASE $ff0 + constant SPI1_SSPPCELLID0
SPI0_BASE $ff4 + constant SPI0_SSPPCELLID1
SPI1_BASE $ff4 + constant SPI1_SSPPCELLID1
SPI0_BASE $ff8 + constant SPI0_SSPPCELLID2
SPI1_BASE $ff8 + constant SPI1_SSPPCELLID2
SPI0_BASE $ffC + constant SPI0_SSPPCELLID3
SPI1_BASE $ffC + constant SPI1_SSPPCELLID3

\             Section 4.5.3
$40050000 constant PWM_BASE     \ PWM base defined PWM_BASE in SDK
PWM_BASE $00 + constant PWM_CH0_CSR \ Control and Status Register
PWM_BASE $04 + constant PWM_CH0_DIV \ INT and FRAC form a fixed point fractional number
PWM_BASE $08 + constant PWM_CH0_CTR \ Direct access to PWM counter
PWM_BASE $0c + constant PWM_CH0_CC  \ Counter compare value 
PWM_BASE $10 + constant PWM_CH0_TOP \ Counter wrap value
PWM_BASE $14 + constant PWM_CH1_CSR \ 8 channels with 2 outputs each
PWM_BASE $18 + constant PWM_CH1_DIV 
PWM_BASE $1c + constant PWM_CH1_CTR 
PWM_BASE $20 + constant PWM_CH1_CC  
PWM_BASE $24 + constant PWM_CH1_TOP 
PWM_BASE $28 + constant PWM_CH2_CSR 
PWM_BASE $2c + constant PWM_CH2_DIV 
PWM_BASE $30 + constant PWM_CH2_CTR 
PWM_BASE $34 + constant PWM_CH2_CC  
PWM_BASE $38 + constant PWM_CH2_TOP 
PWM_BASE $3c + constant PWM_CH3_CSR 
PWM_BASE $40 + constant PWM_CH3_DIV 
PWM_BASE $44 + constant PWM_CH3_CTR 
PWM_BASE $48 + constant PWM_CH3_CC  
PWM_BASE $4c + constant PWM_CH3_TOP 
PWM_BASE $50 + constant PWM_CH4_CSR 
PWM_BASE $54 + constant PWM_CH4_DIV 
PWM_BASE $58 + constant PWM_CH4_CTR 
PWM_BASE $5c + constant PWM_CH4_CC 
PWM_BASE $60 + constant PWM_CH4_TOP 
PWM_BASE $64 + constant PWM_CH5_CSR
PWM_BASE $68 + constant PWM_CH5_DIV 
PWM_BASE $6c + constant PWM_CH5_CTR 
PWM_BASE $70 + constant PWM_CH5_CC  
PWM_BASE $74 + constant PWM_CH5_TOP 
PWM_BASE $78 + constant PWM_CH6_CSR 
PWM_BASE $7c + constant PWM_CH6_DIV 
PWM_BASE $80 + constant PWM_CH6_CTR 
PWM_BASE $84 + constant PWM_CH6_CC  
PWM_BASE $88 + constant PWM_CH6_TOP 
PWM_BASE $8c + constant PWM_CH7_CSR 
PWM_BASE $90 + constant PWM_CH7_DIV 
PWM_BASE $94 + constant PWM_CH7_CTR 
PWM_BASE $98 + constant PWM_CH7_CC  
PWM_BASE $9c + constant PWM_CH7_TOP 
PWM_BASE $a0 + constant PWM_EN      \ EN bit for all channels for sync purposes
PWM_BASE $a4 + constant PWM_INTR    \ Raw interrupts
PWM_BASE $a8 + constant PWM_INTE    \ Interrupt enable
PWM_BASE $ac + constant PWM_INTF    \ Interrupt force
PWM_BASE $b0 + constant PWM_INTS    \ Interrupt status

\ Section 4.9.5 ADC_BASE
\ MUST DISABLE IN PADS_BANK0! If using GPIO pins for ADC! 
\ Set IE {bit 6} low and OD {bit 7} high!
$4004c000 constant ADC_BASE         \ ADC_BASE in SDK
ADC_BASE $00 + constant ADC_CS      \ ADC Control and Status
ADC_BASE $04 + constant ADC_RESULT  \ Result of most recent ADC conversion
ADC_BASE $08 + constant ADC_FCS     \ FIFO control and status
ADC_BASE $0c + constant ADC_FIFO    \ Conversion result FIFO
ADC_BASE $10 + constant ADC_DIV     \ Clock divider
ADC_BASE $14 + constant ADC_INTR    \ Raw Interrupts
ADC_BASE $18 + constant ADC_INTE    \ Interrupt Enable
ADC_BASE $1c + constant ADC_INTF    \ Interrupt Force
ADC_BASE $20 + constant ADC_INTS    \ Interrupt status


\ Section 2.19.6.3 PADS_BANK0_BASE User bank
create pads $4001C004 , $4001C008 , $4001C00C , $4001C010 , $4001C014 , $4001C018 , $4001C01C , $4001C020 , $4001C024 , $4001C028 ,
$4001C02C , $4001C030 , $4001C034 , $4001C038 , $4001C03C , $4001C040 , $4001C044 , $4001C048 , $4001C04C , $4001C050 ,
$4001C054 , $4001C058 , $4001C05C , $4001C060 , $4001C064 , $4001C068 , $4001C06C , $4001C070 , $4001C074 , $4001C078 ,

create pin-addr $00000001 , $00000002 , $00000004 , $00000008 , $00000010 , $00000020 , $00000040 , $00000080 , $00000100 , $00000200 ,
$00000400 , $00000800 , $00001000 , $00002000 , $00004000 , $00008000 , $00010000 , $00020000 , $00040000 , $00080000 ,
$00100000 , $00200000 , $00400000 , $00800000 , $01000000 , $02000000 , $04000000 , $08000000 , $10000000 , $20000000 ,

0 constant pin0
1 constant pin1
2 constant pin2
3 constant pin3
4 constant pin4
5 constant pin5
6 constant pin6
7 constant pin7
8 constant pin8
9 constant pin9
10 constant pin10
11 constant pin11
12 constant pin12
13 constant pin13
14 constant pin14
15 constant pin15 \ do not use on pico
16 constant pin16
17 constant pin17
18 constant pin18
19 constant pin19
20 constant pin20
21 constant pin21
22 constant pin22
23 constant pin23
24 constant pin24
25 constant pin25
26 constant pin26
27 constant pin27
28 constant pin28
29 constant pin29

0 constant lo
1 constant hi

\ General pin functions
: set-hi ( pin# -- ) pin-addr swap 4 * + @ SIO_GPIO_OUT_SET ! ;

: set-lo ( pin# -- ) pin-addr swap 4 * + @ SIO_GPIO_OUT_CLR ! ;

: to-output ( pin# -- ) pin-addr swap 4 * + @ SIO_GPIO_OE_SET ! ;

: to-input ( pin# -- ) pin-addr swap 4 * + @ SIO_GPIO_OE_CLR ! ;

: set-out-fast ( pin# -- ) pads swap 4 * + @ dup @ $01 or swap ! ;

: set-out-slow ( pin# -- ) pads swap 4 * + @ dup @ $FE and swap ! ;

: set-in-schmitt ( pin# -- ) pads swap 4 * + @ dup @ $02 or swap ! ;

: set-in-no-schmitt ( pin# -- ) pads swap 4 * + @ dup @ $CD and swap ! ;
\ clr other pull
: set-pulldn ( pin# -- ) pads swap 4 * + @ dup dup dup @ $04 or swap ! @ $F7 and swap ! ;
: set-pullup ( pin# -- ) pads swap 4 * + @ dup dup dup @ $08 or swap ! @ $FB and swap ! ;
: set-floating ( pin# -- ) pads swap 4 * + @ dup @ $F3 and swap ! ;
: set-out-drive2 ( pin# -- ) pads swap 4 * + @ dup dup dup @ $CF and swap ! @ $00 or swap ! ;

: set-out-drive4 ( pin# -- ) pads swap 4 * + @ dup dup dup @ $CF and swap ! @ $10 or swap ! ;

: set-out-drive8 ( pin# -- ) pads swap 4 * + @ dup dup dup @ $CF and swap ! @ $20 or swap ! ;

: set-out-drive12 ( pin# -- ) pads swap 4 * + @ dup dup dup @ $CF and swap ! @ $30 or swap ! ;

: enable-input ( pin# -- ) pads swap 4 * + @ dup @ $40 or swap ! ;

: disable-input ( pin# -- ) pads swap 4 * + @ dup @ $BF and swap ! ;

: enable-output ( pin# -- ) pads swap 4 * + @ dup @ $80 or swap ! ;

: disable-output ( pin# -- ) pads swap 4 * + @ dup @ $7F and swap ! ;

\ SPI functions
: reset-spi0 RESETS_RESET @ $00010000 or RESETS_RESET ! ;

: un-reset-spi0 RESETS_RESET @ $FFFEFFFF and RESETS_RESET ! ;

: reset-spi1 RESETS_RESET @ $00020000 or RESETS_RESET ! ;

: un-reset-spi1 RESETS_RESET @ $FFFDFFFF and RESETS_RESET ! ;

: setup-spi0
  reset-spi0 \ reset spi0
  un-reset-spi0
  $0001 IO_BANK0_GPIO19_CTRL ! \ sel SPI0 MOSI
  $0001 IO_BANK0_GPIO18_CTRL ! \ sel SPI0 SCL
  $0001 IO_BANK0_GPIO16_CTRL ! \ sel SPI0 MISO
  $0007 SPI0_SSPCR0 ! \ select 8-bit transfers
  $0010 SPI0_SSPCPSR ! \ even values 2 .. 254 $10 gives 7.8 MHz SPI bit clock
  \ with 125 MHz default PCLK input,
  \ normal value of 2 gives 62.5 MHz SPI bit clock if SCR value in CR0 = 0;
  \ if value is 4, gives 31.25 MHz; 6 gives 20.83 MHz; 8 gives 15.6 MHz; etc.
  \ You can get finer divisions by using a nonzero CR0 SCR parameter (range 0 .. 255).
  \ F_SPI_CLK_OUT = F_SSPCLK (normally PCLK) / (CPSDVSR * (1 + SCR))
  $0003 SPI0_SSPDMACR ! \ enable dma
  $0002 SPI0_SSPCR1 ! \ enable SPI0

;
: setup-spi1
  reset-spi1 \ reset spi1
  un-reset-spi1
  $0001 IO_BANK0_GPIO11_CTRL ! \ sel SPI0 MOSI
  $0001 IO_BANK0_GPIO10_CTRL ! \ sel SPI0 SCL
  $0001 IO_BANK0_GPIO12_CTRL ! \ sel SPI0 MISO
  $0007 SPI1_SSPCR0 ! \ select 8-bit transfers
  $0010 SPI1_SSPCPSR ! \ normal 2
  $0003 SPI1_SSPDMACR ! \ enable dma
  $0002 SPI1_SSPCR1 ! \ enable SPI1

;

: set-spi0-8bit $0007 SPI0_SSPCR0 ! ;

: set-spi0-16bit $000F SPI0_SSPCR0 ! ;

: set-spi1-8bit $0007 SPI1_SSPCR0 ! ;

: set-spi1-16bit $000F SPI1_SSPCR0 ! ;

$0010 constant spi-sr-bsy \ or mask
: spi0-16> ( n -- ) $000F SPI0_SSPCR0 ! SPI0_SSPDR ! begin SPI0_SSPSR @ spi-sr-bsy and 0= until ;

: spi0-8> ( c -- ) $0007 SPI0_SSPCR0 ! SPI0_SSPDR ! begin SPI0_SSPSR @ spi-sr-bsy and 0= until ;

: spi1-16> ( n -- ) $000F SPI1_SSPCR0 ! SPI1_SSPDR ! begin SPI1_SSPSR @ spi-sr-bsy and 0= until ;

: spi1-8> ( c -- ) $0007 SPI1_SSPCR0 ! SPI1_SSPDR ! begin SPI1_SSPSR @ spi-sr-bsy and 0= until ;

\ Pico Display button functions
: init-buttons  pin12 to-input pin12 set-pullup  \ button A
                pin13 to-input pin13 set-pullup  \ button B
                pin14 to-input pin14 set-pullup  \ button X
                pin15 to-input pin15 set-pullup  \ button Y
;

: get-curr-state ( pin# -- state)  pin-addr swap 4 * + @ SIO_GPIO_IN @ and 0= if 0 else 1 then ;

\ for reading switch inputs with a little debouncing delays
: is-high? ( pin# -- state) dup dup get-curr-state #06 ms swap get-curr-state #06 ms rot get-curr-state #06 ms + swap + 3 = ;
: is-low? ( pin# -- state) dup dup get-curr-state #06 ms swap get-curr-state #06 ms rot get-curr-state #06 ms + swap + 0= ;


: is-A-pressed  pin12 is-low? ;  \ these go low when pressed
: is-B-pressed  pin13 is-low? ;  \ so now-zero result means pressed
: is-X-pressed  pin14 is-low? ;
: is-Y-pressed  pin15 is-low? ;

\ Pico Display PWM functions 

: pimo_disp_pwm_init
  $04 IO_BANK0_GPIO6_CTRL !   \ set function to PWM
  $04 IO_BANK0_GPIO7_CTRL ! 
  $04 IO_BANK0_GPIO8_CTRL !
  $04 IO_BANK0_GPIO20_CTRL !
  1 dup PWM_CH2_CSR ! dup PWM_CH3_CSR ! PWM_CH4_CSR !  \ Enable CH2, CH3, CH4
;

: set_LED3   \ just set the counter compare for R - GPIO6 PWM3A, G - GPIO7 PWM3B 
             \ B - GPIO8 PWM4A and enable PWM3 and PWM4. 
             \ 3 values will be taken from stack for Red, Green, Blue 0 - 65535
   PWM_CH4_CC !                   \ Red in bottom 16 CH4
   16 lshift or PWM_CH3_CC !      \ Blue shifted left 16 or green
;
: set_BL       \ expects number 0-65535 on stack
  PWM_CH2_CC !     \ PWM2A gets the number in bits 15:0
;
: LED3_example
   pimo_disp_pwm_init
  12 1000 4000 set_LED3
;

: BL_example
\   bl_disp_pwm_init
   0 dup set_BL
   4 0 do
     6 0 do 
       10000 + dup set_BL
        2050000 0 do loop
      loop
    loop
   drop
;

\: BL_example
\  16000 set_BL
\;

: cycle_LED3 \ needs work
0 dup dup dup set_LED3 
4 0 do 
  6 0 do 
    10000 - dup set_LED3 
     2050000 0 do loop 
    loop  
   loop 
  drop 
; 

\ ADC Temperature example. Needs ADC Registers.
: temperature ( -- u )

  %11 ADC_CS !                 \ Enable ADC and temperature sensor
  begin $100 ADC_CS bit@ until \ Wait for READY flag
  4 12 lshift %111 or ADC_CS ! \ Start conversion on channel 4, temperature sensor
  begin $100 ADC_CS bit@ until \ Wait for READY flag
  ADC_RESULT @                 \ Fetch conversion result
;

: adc>u ( u -- f ) 0 swap 3,3 4096,0 f/ f*  1-foldable ; \ Convert ADC result in voltage reading

: u>degreeC ( f -- f' ) \ T = 27 - (ADC_voltage - 0.706)/0.001721

  0,706 d-
  1,0 0,001721 f/ f*
  27,0 2swap d-

2-foldable ;

: C>F 9,0 f* 5,0 f/ 32,0 d+ 2-foldable ;

: t ( -- )
  begin
    temperature dup hex. ." : "
    adc>u 2dup 3 f.n ." V "
    u>degreeC 2dup 1 f.n ." °C " 
    C>F 2 f.n ." °F " cr
    100 ms
  key? until
;

