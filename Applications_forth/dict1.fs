\ dictionary 1 - temporary program storage program for testing
compiletoflash
\ programs go here remember 1 load# to load this dict

\ test_gpio - Interactive program to test all gpio pins on a board
forgetram

\ test_GPIO Messages
: .enter_GPIO grey ." Enter GPIO to test or a for adieu: (#2-29) " black ;
: .GPIO_UT grey ." GPIO under test is: " black ;
: .GPIO_range cr grey ." Interactive GPIO test, GPIO range is " minGPIO . ." - " maxGPIO . cr black ;
: .enter_Tests grey ." Enter Test to run: (0-3) " black ;
: .Test_range grey ." Tests: 0=> new GPIO 1=> High 2=> Low  3=> Blink once " black ;
: .adieu green ." Adieu " black ;
: .err_GPIO fuchsia ." Error: Check GPIO range: " black ;
: .err_Test fuchsia ." Error: Check Test range: " black ;
: .err_input fuchsia ." Error: Check input value: " black ;
: .err_val_low fuchsia ." Error: Value too low: " black ;
: .err_val_high fuchsia ." Error: Value too high: " black ;
: .err_not_number fuchsia ." Error: Not a number: " black ;
: .err_stack red ." Error: Depth of stack not 0 " black ;

\ state variables
false variable adieu_state \ the state in which to adieu the program
: clr_adieu false adieu_state ! ;       \ continue testing
: set_adieu true adieu_state ! ;        \ adieu test_GPIO
: adieu_state? adieu_state @ ;
: .adieu_st ." adieu_state is " adieu_state @ . ;

false variable test0_state \ the state in which to stop testing
: clr_test0 false test0_state ! ;   \ test not 0, continue testing
: set_test0 true test0_state ! ;    \ test is 0, adieu testing
: test0_state? test0_state @ ;
: .test0_st ." Test_state is " test0_state @ . ;

false variable GPIO_state \ the state in which to request a GPIO pin
: clr_gpio_st false GPIO_state ! ;  \ GPIO is known, request Test
: set_gpio_st true GPIO_state ! ;   \ GPIO is unknown, request GPIO
: GPIO_state? GPIO_state @ ;
: .GPIO_st ." GPIO_state is " GPIO_state @ . ;

13 variable gpio \ GPIO to be tested, initialized to on-board LED

: adieu? ( c -- c T | c F ) \ test if char is 'a' to adieu
    dup [char] a =
;

: check_stack
    depth 0<>
    if .err_stack red .s black
    then
;

: error_GPIO ( n -- ) \ print GPIO error, GPIO value, clear GPIO_state
    .err_GPIO .
    clr_gpio_st
;

: error_input ( n -- ) \ print input error, input value, clear GPIO_state
    .err_input .
    clr_gpio_st
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

: ctoGPIO ( -- n T | c F)  \ get one or two char and make them decimals or error
    get_2c 1 - 0= if pad c@ one_digit else pad two_digits then
;

: ctoTest ( n -- n T| c F ) \ get one char and return decimal or error
    get_1c drop pad c@ one_digit
;

: range? ( min max v -- T | F ) \ returns flag as to value being in range, inclusive
    dup >r          ( min max v ) ( v )
    >= swap r>      ( f min v ) ( )
    <= and          ( f )
;

: adieu ( n -- ) \ drop GPIO value, set states to adieu and print adieu
    set_adieu set_gpio_st set_test0
    drop
    cr .adieu
;

\ Tests to run: 0=> new GPIO 1=> High 2=> Low  3=> Blink once
: test_0 ( -- ) \ Leave testing and request new GPIO
    cr set_test0 set_gpio_st clr_adieu
;
: test_1 ( -- ) \ Set GPIO High
    gpio @
    high_GPIO
    clr_test0
;
: test_2 ( -- ) \ Set GPIO Low
    gpio @
    low_GPIO
    clr_test0
;
: test_3 ( -- ) \ Blink GPIO once
    gpio @
    dup tog_GPIO
    tenth_sec
    tog_GPIO
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

: get_test ( -- ) \ testing loop, continue to loop until test0_state is true
    decimal
    begin
        cr .enter_Tests
        ctoTest
        if tests
        else error_NaN
        then
        test0_state?
    until
;

: init_test ( -- ) \ clear adieu and testing states, set GPIO state and request GPIO
    erase_pad set_gpio_st clr_adieu clr_test0
    cr .enter_GPIO
;

: init_gpio ( n -- ) \ initialize GPIO to be F5 and an output, initial state not saved
    cr
    dup gpio !
    dup .GPIO_UT .
    dup GPIO_F5 GPIO_OUT
    set_gpio_st
;

: test_gpio ( -- )
    .GPIO_range
    begin
        .Test_range
        begin
            init_test
            ctoGPIO
            if dup minGPIO maxGPIO rot range?
                if init_gpio
                else error_GPIO
                then
            else adieu?
                if adieu
                else error_input
                then
            then
            GPIO_state?
        until
            test0_state? not
            if get_test
            then
        adieu_state?
    until
    check_stack
;
\ keep the following lines
: endofDict1 ;
1 save#
compiletoram

