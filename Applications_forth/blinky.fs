\ blinky ( n -- ) blinks on-board led n ms
\ requires dict1.fs for constants
\ requires pin13 to be SIO (F5) DS_p258

: blinky ( n -- ) \ blinks on-board led n ms

  1 LED lshift GPIO_OE !

  begin
    dup
    1 LED lshift GPIO_OUT_XOR !
    ms
  key? until
;

