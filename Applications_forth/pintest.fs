\ Pintest - Interactive program to test all gpio Pins on a board
\ 			using Pin numbers
forgetram

\ state variables
false variable adieu_state \ the state in which to adieu the program
: clr_adieu false adieu_state ! ;		\ continue testing
: set_adieu true adieu_state ! ;		\ adieu Pintest
: adieu_state? adieu_state @ ;
: .adieu_st ." adieu_state is " adieu_state @ . ;

false variable new_state \ the state in which to request a new Pin
: clr_test0 false new_state ! ;	\ test not 0, continue testing on current Pin
: set_test0 true new_state ! ;	\ test is 0, stop testing and request new Pin
: new_state? new_state @ ;
: .test0_st ." Test_state is " new_state @ . ;

false variable Pin_state \ the state in which to request a Pin Pin
: clr_Pin_st false Pin_state ! ;	\ Pin is known, request Test
: set_Pin_st true Pin_state ! ;	\ Pin is unknown, request Pin
: Pin_state? Pin_state @ ;
: .Pin_st ." Pin_state is " Pin_state @ . ;

13 variable Pin \ Pin to be tested, initialized to on-board LED

: adieu? ( c -- c T | c F ) \ test if char is 'a' to adieu
    dup [char] a =
;

: check_stack
	depth 0<>
	if .err_stack red .s black
	then
;

: error_Pin ( n -- ) \ print Pin error, Pin value, clear Pin_state
	.err_Pin .
	clr_Pin_st
;

: error_input ( n -- ) \ print input error, input value, clear Pin_state
	.err_input . 
	clr_Pin_st
;

: error_NaN ( n -- ) \ print error, value entered, set flag to false for bad value
	.err_not_number .
;

: error_Test ( n -- ) \ print error, value entered, set flag to false for bad value
	.err_Test .
;

: one_digit ( c -- n T | c F ) \ test if char is decimal , return decimal or error
   dup decimal digit
   if swap drop true
   else false
   then
;

: two_digits ( addr -- n T | c F ) \ test if two char are decimal, return decimal or error
   decimal c@ digit 
   if 10 * pad 1 + c@ digit 
        if + true 
        else drop pad 1 + c@ false 
        then
   else pad c@ false 
   then 
;

: get_1c ( -- n ) \ get only 1 char into buffer, pad
	pad 1 accept ;

: get_2c ( -- n ) \ get upto 2 char into buffer, pad
	pad 2 accept ; 

: ctoPin ( -- n T | c F)  \ get one or two char and make them decimals or error
    get_2c 1 - 0= if pad c@ one_digit else pad two_digits then
;

: ctoTest ( n -- n T| c F ) \ get one char and return decimal or error
    get_1c drop pad c@ one_digit
;

: range? ( min max v -- T | F ) \ returns flag as to value being in range, inclusive
	dup >r			( min max v ) ( v )
	>= swap r>		( f min v ) ( )
	<= and			( f )
;

: adieu ( n -- ) \ drop Pin value, set states to adieu and print adieu
	set_adieu set_Pin_st set_test0
	drop 
	cr .adieu 
;

\ Tests to run: 0=> new Pin 1=> High 2=> Low  3=> Blink once
: test_0 ( -- ) \ Leave testing and request new Pin
	cr set_test0 set_Pin_st clr_adieu
;
: test_1 ( -- ) \ Set Pin High
	Pin @
	high_Pin
	clr_test0
;
: test_2 ( -- ) \ Set Pin Low
	Pin @
	low_Pin
	clr_test0
;
: test_3 ( -- ) \ Blink Pin once
	Pin @
	dup tog_Pin
	tenth_sec
	tog_Pin
	qtr_sec
	clr_test0
;
: tests ( n -- ) \ Run test based on value or print error
	case
		0 of test_0 endof
		1 of test_1 endof
		2 of test_2 endof
		3 of test_3 endof
		dup .err_Test . clr_test0
	endcase
;

: get_test ( -- ) \ testing loop, continue to loop until new_state is true
    decimal
    begin 
	    cr .enter_Tests 
	    ctoTest
	    if tests
	    else error_NaN
	    then
	    new_state?
    until
;

: init_test ( -- ) \ clear adieu and testing states, set Pin state and request Pin
	erase_pad set_Pin_st clr_adieu clr_test0
	cr .enter_Pin
;

: init_Pin ( n -- ) \ initialize Pin to be F5 and an output, initial state not saved
	cr
	dup Pin !
	dup .Pin_to_Test .
	dup Pin_F5 Pin_OUT
	set_Pin_st
;

: Pintest ( -- )
	.Pin_range
	begin
		.Test_range
		begin	
			init_test
			ctoPin
			if dup minPin maxPin rot range?
				if init_Pin
				else error_Pin
				then
			else adieu?
				if adieu
				else error_input
				then
			then
			Pin_state?
		until
			new_state? not
			if get_test
			then
		adieu_state?
	until
	check_stack
;
