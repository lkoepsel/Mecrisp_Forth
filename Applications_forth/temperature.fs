
\ Small example on how to use the Analog-Digital-Converter.

$4004c000 $00 + constant ADC-CS     \ ADC Control and Status
$4004c000 $04 + constant ADC-RESULT \ Result of most recent ADC conversion
$4004c000 $08 + constant ADC-FCS    \ FIFO control and status
$4004c000 $0c + constant ADC-FIFO   \ Conversion result FIFO
$4004c000 $10 + constant ADC-DIV    \ Clock divider. If non-zero, CS_START_MANY will start conversions at regular intervals rather than back-to-back.
                                    \ The divider is reset when either of these fields are written. Total period is 1 + INT + FRAC / 256
$4004c000 $14 + constant ADC-INTR   \ Raw Interrupts
$4004c000 $18 + constant ADC-INTE   \ Interrupt Enable
$4004c000 $1c + constant ADC-INTF   \ Interrupt Force
$4004c000 $20 + constant ADC-INTS   \ Interrupt status after masking & forcing

: temperature ( -- u )

  %11 adc-cs !                 \ Enable ADC and temperature sensor
  begin $100 adc-cs bit@ until \ Wait for READY flag
  4 12 lshift %111 or adc-cs ! \ Start conversion on channel 4, temperature sensor
  begin $100 adc-cs bit@ until \ Wait for READY flag
  adc-result @                 \ Fetch conversion result
;

: adc>u ( u -- f ) 0 swap 3,3 4096,0 f/ f*  1-foldable ; \ Convert ADC result in voltage reading

: u>degreeC ( f -- f' ) \ T = 27 - (ADC_voltage - 0.706)/0.001721

  0,706 d-
  1,0 0,001721 f/ f*
  27,0 2swap d-

2-foldable ;

: temp ( -- )
  begin
    temperature dup hex. ." : "
                    adc>u 2dup 3 f.n ." V "
                          u>degreeC 1 f.n ." °C" cr
  1000 ms 1 bp
  key? until
;
