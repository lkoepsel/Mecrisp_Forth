\ main dictionary for words which have been debugged
compiletoflash
: words4 ( -- ) cr  \ A columnar Word list printer. Width = 20 characters, handles overlength Words neatly 
   0				    \ column counter
   dictionarystart
      begin
	 dup 6 + dup
	 ctype			    \ dup before 6 is for dictionarynext input
	 count nip		    \ get number of characters in the word and drop the address of the word
	     20 swap - dup 0 > if   \ if Word is less than 20 chars
		   spaces swap	    \ pad with spaces to equal 20 chars
		   else drop cr	    \ issue immediate carriage return and drop negative number
		   nip -1	    \ and reset to column -1
		   then		       
		      dup 3 = if 3 - cr \ if at 4th column, zero column counter			   
		      else 1 +
		      then
	 swap		       
	 dictionarynext		    \ 	( a-addr - - a-addr flag )
      until
   2drop
;

: freememory ( -- )
	compiletoflash unused ." FLASH: " .
	compiletoram unused ." RAM: " .
;

\ xterm colors 256!
\ https://github.com/sindresorhus/xterm-colors
: esc 27 emit ;
: black      ( -- cursor colour )  esc ." [38;5;0m" ;
: red        ( -- cursor colour )  esc ." [38;5;9m" ;
: green      ( -- cursor colour )  esc ." [38;5;2m" ;
: purple     ( -- cursor colour )  esc ." [38;5;93m" ;
: blue       ( -- cursor colour )  esc ." [38;5;12m" ;
: magenta    ( -- cursor colour )  esc ." [38;5;127m" ;
: cyan       ( -- cursor colour )  esc ." [38;5;51m" ;
: white      ( -- cursor colour )  esc ." [38;5;15m" ;
: grey       ( -- cursor colour )  esc ." [38;5;8m" ;
: fuchsia    ( -- cursor colour )  esc ." [38;5;13m" ;
: green3     ( -- cursor colour )  esc ." [38;5;34m" ;
: lime       ( -- cursor colour )  esc ." [38;5;10m" ;
: navy       ( -- cursor colour )  esc ." [38;5;4m" ;
: darkorange ( -- cursor colour )  esc ." [38;5;208m" ;
: grey62     ( -- cursor colour )  esc ." [38;5;247m" ;
: grey82     ( -- cursor colour )  esc ." [38;5;252m" ;

: test_black      black      ." BLACK black " black ;
: test_red        red        ." RED red " black ;
: test_green      green      ." GREEN green " black ;
: test_purple     purple     ." PURPLE purple " black ;
: test_blue       blue       ." BLUE blue " black ;
: test_magenta    magenta    ." MAGENTA magenta " black ;
: test_cyan       cyan       ." CYAN cyan" black ;
: test_white      white      ." WHITE white " black ;
: test_grey       grey       ." GREY grey " black ;
: test_fuchsia    fuchsia    ." FUCHSIA fuchsia " black ;
: test_green3     green3     ." GREEN3 green3 " black ;
: test_lime       lime       ." LIME lime " black ;
: test_navy       navy       ." NAVY navy " black ;
: test_darkorange darkorange ." DARKORANGE darkorange " black ;
: test_grey62     grey62     ." GREY62 grey62 " black ;
: test_grey82     grey82     ." GREY82 grey82 " black ;

: colors 
        cr test_black cr test_grey cr test_grey62 cr test_grey82 
        cr test_white cr test_red cr test_darkorange cr test_lime
        cr test_green3 cr test_green cr test_cyan cr test_blue
        cr test_navy cr test_magenta cr test_fuchsia cr test_purple
        cr
;

: bp blue cr . .s cr black ;

\ Feather RP2040 localization
#1						constant minPin
#40					constant maxPin
#0						constant minTest
#3						constant maxTest
#8						constant padsize

$40014000 			constant IO_BANK0_GPIO0_STATUS \ GPIO status
$40014004 			constant IO_BANK0_GPIO0_CTRL \ GPIO control including function select and overrides.
$d0000000 			constant SIO_BASE

#5 			    constant SIO 				\ SIO (F5) DS_p258
SIO_BASE $004 + constant GPIO_IN       \ Input value for GPIO
SIO_BASE $010 + constant GPIO_OUT      \ GPIO output value
SIO_BASE $014 + constant GPIO_OUT_SET  \ GPIO output value set
SIO_BASE $018 + constant GPIO_OUT_CLR  \ GPIO output value clear
SIO_BASE $01c + constant GPIO_OUT_XOR  \ GPIO output value XOR
SIO_BASE $020 + constant GPIO_OE       \ GPIO output enable
SIO_BASE $024 + constant GPIO_OE_SET   \ GPIO output enable set
SIO_BASE $028 + constant GPIO_OE_CLR   \ GPIO output enable clear
SIO_BASE $02c + constant GPIO_OE_XOR   \ GPIO output enable XOR

\ GP constants
$80					constant GP0 \ high bit indicates not a GP or can't be used
$81	 				constant GP1
#2						constant GP2
#3						constant GP3
#4						constant GP4
#5						constant GP5
#6						constant GP6
#7						constant GP7
#8						constant GP8
#9						constant GP9
#10					constant GP10
#11					constant GP11
#12					constant GP12
#13					constant GP13
#14					constant GP14
#15					constant GP15
#16					constant GP16
#17					constant GP17
#18					constant GP18
#19					constant GP19
#20					constant GP20
#21					constant GP21
#22					constant GP22
$97	   			constant GP23 \ $17 (#23) + $80
$98   				constant GP24
$99					constant GP25
#26					constant GP26
#27					constant GP27
#28					constant GP28
$9D					constant GP29
$C0					constant GND \ special number for GND
$9e					constant RUN
$a3					constant ADC_REF
$a4					constant 3V3
$a5					constant 3V3_EN
$a7					constant VSYS
$a8					constant VBUS

\ Use Pico Pin # (1-40) instead of GPn
\ RP2040 Pin to GP Translation
create PINS $ffff ,	\ not a Pin
         GP0 ,			\ Pin 1
			GP1 ,			\ Pin 2
			GND ,			\ Pin 3
			GP2 ,			\ Pin 4
			GP3 ,			\ Pin 5
			GP4 ,			\ Pin 6
			GP5 ,			\ Pin 7
			GND ,			\ Pin 8
			GP6 ,			\ Pin 9
			GP7 ,			\ Pin 10
			GP8 ,			\ Pin 11
			GP9 ,			\ Pin 12
			GND ,			\ Pin 13
			GP10 ,		\ Pin 14
			GP11 ,		\ Pin 15
			GP12 ,		\ Pin 16
			GP13 ,		\ Pin 17
			GND ,			\ Pin 18
			GP14 ,		\ Pin 19
			GP15 ,		\ Pin 20
			GP16 ,		\ Pin 21
			GP17 ,		\ Pin 22
			GND ,			\ Pin 23
			GP18 ,		\ Pin 24
			GP19 ,		\ Pin 25
			GP20 ,		\ Pin 26
			GP21 ,		\ Pin 27
			GND ,			\ Pin 28
			GP22 ,		\ Pin 29
			RUN ,			\ Pin 30
			GP26 ,		\ Pin 31
			GP27 ,		\ Pin 32
			GND ,			\ Pin 33
			GP28 ,		\ Pin 34
			ADC_REF , 	\ Pin5 3
			3V3 ,			\ Pin 36
			3V3_EN , 	\ Pin7 3
			GND ,			\ Pin 38
			VSYS ,		\ Pin 39
			VBUS ,		\ Pin 40

: PIN2GP cells PINS + @ ;

: GPIO_ctrl ( GPIO -- ) \ get the address for the specific GPIO ctrl register
	#8 * IO_BANK0_GPIO0_CTRL +
;

\ print values of the GPIO_CTRL registers of all GPIO pins
: .CTRL ( -- ) \ print CTRL values of all GPIO pins
	30 0 CR DO 
	I GPIO_ctrl @
	I . . CR
	LOOP 
;

: one_sec ( -- ) 		\ one sec ( -- )ond delay
	1000 ms
;

: half_sec ( -- )		\ half sec ( -- )ond delay
	500 ms
;

: qtr_sec ( -- )		\ quarter sec ( -- )ond delay
	250 ms
;

: tenth_sec ( -- )		\ tenth sec ( -- )ond delay
	100 ms
;

: valid_GPIO? ( pin -- f ) \ return True if valid GPIO pin
    PIN2GP DUP $80 and
    if false
    else true
    then
;

: GPIO_F5 ( GPIO -- )		\ ensure GPIO is in F5
	dup GPIO_ctrl 
	@ %11111 and
	5 = if drop else ." Not F5! " 5 swap GPIO_ctrl ! then
;

: GPIO_OUT ( GPIO -- )	\ set GPIO to output, uses atomic set
	1 swap lshift GPIO_OE_SET !
;

: tog_GPIO ( GPIO -- )	
	1 swap lshift GPIO_OUT_XOR !
;

: high_GPIO ( GPIO -- )	
	1 swap lshift GPIO_OUT_SET !
;

: low_GPIO ( GPIO -- )	
	1 swap lshift GPIO_OUT_CLR !
;

: blink_GPIO ( GPIO -- ) 
	dup GPIO_F5
	dup GPIO_OUT 
	  begin
	    dup tog_GPIO
	    tenth_sec ( -- )
	  key? until drop
; 

: ms_blink_GPIO ( n GPIO -- ) \ blink GPIO every n milliseconds, until key
	dup GPIO_F5
	dup GPIO_OUT 
	  begin
	    dup tog_GPIO
	    swap dup ms swap
	  key? until drop drop
; 

: us_blink_GPIO ( n GPIO -- ) \ blink GPIO every n microseconds, infinite
	dup GPIO_F5
	dup GPIO_OUT 
	  begin
	    dup tog_GPIO
	    swap dup us swap
	  again drop drop
; 

: PIN_high ( n PIN# -- ) \ set a pin high
	PIN2GP DUP
	GPIO_OUT high_GPIO
;

: PIN_low ( n PIN# -- ) \ set a pin low
	PIN2GP DUP
	GPIO_OUT low_GPIO
;

: PIN_tog ( n PIN# -- ) \ set a pin low
	PIN2GP DUP
	GPIO_OUT tog_GPIO
;

padsize buffer: pad
: .pad 
	padsize 0 do 
   pad I + c@ hex .
   loop
;

: erase_pad 
	padsize 0 do 
   0 pad I + c! 
   loop 
;

: range? ( min max v -- T | F ) \ returns flag as to value being in range, inclusive
	dup >r			( min max v ) ( v )
	>= swap r>		( f min v ) ( )
	<= and			( f )
;

: endofDict0 ;
0 save#
compiletoram
