\ test_Pin - Interactive program to test all valid gpio pins on a board
\ Uses pin # as an input and translates to GPIO
forgetram

\ test_Pin Messages
: .enter_Pin grey ." Enter Pin to test for GPIO or a for adieu: (#1-40) " black ;
: .Pin_UT grey ." Pin under test is: " black ;
: .GPIO_UT grey ." GPIO under test is: " black ;
: .Pin_range cr grey ." GPIO Pin test, Pin range is " minPin . ." - " maxPin . cr black ;
: .enter_Tests grey ." Enter Test to run: (0-3) " black ;
: .Test_range grey ." Tests: 0=> new Pin 1=> High 2=> Low  3=> Blink once " black ;
: .adieu green ." Adieu " black ;
: .err_Pin fuchsia ." Error: Invalid Pin for GPIO pin: " black ;
: .err_Test fuchsia ." Error: Check Test range: " black ;
: .err_input fuchsia ." Error: Check input value: " black ;
: .err_val_low fuchsia ." Error: Value too low: " black ;
: .err_val_high fuchsia ." Error: Value too high: " black ;
: .err_not_number fuchsia ." Error: Not a number: " black ;
: .err_stack red ." Error: Depth of stack not 0 " black ;

false variable adieu_state \ the state in which to adieu the program
: clr_adieu false adieu_state ! ; \ continue testing
: set_adieu true adieu_state ! ; \ adieu test_Pin
: adieu_state? adieu_state @ ;
: .adieu_st ." adieu_state is " adieu_state @ . ;

false variable test0_state \ the state in which to stop testing
: clr_test0 false test0_state ! ; \ test not 0, continue testing
: set_test0 true test0_state ! ; \ test is 0, adieu testing
: test0_state? test0_state @ ;
: .test0_st ." Test_state is " test0_state @ . ;

false variable Pin_state \ the state in which to request a Pin pin
: clr_gpio_st false Pin_state ! ; \ Pin is known, request Test
: set_gpio_st true Pin_state ! ; \ Pin is unknown, request Pin
: Pin_state? Pin_state @ ;
: .Pin_st ." Pin_state is " Pin_state @ . ;

4 variable Pin \ Pin to be tested, initialized to lowest pin
2 variable gpio \ gpio to be tested, initialized to lowest GP

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
    clr_gpio_st
;

: error_input ( n -- ) \ print input error, input value, clear Pin_state
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

: ctoPin ( -- n T | c F )  \ get one or two char and make them decimals or error
    get_2c 1 - 0= if pad c@ one_digit else pad two_digits then
;

: ctoTest ( n -- n T| c F ) \ get one char and return decimal or error
    get_1c drop pad c@ one_digit
;

: adieu ( n -- ) \ drop Pin value, set states to adieu and print adieu
    set_adieu set_gpio_st set_test0
    drop
    cr .adieu
;

\ Tests to run: 0=> new Pin 1=> High 2=> Low  3=> Blink once
: test_0 ( -- ) \ Leave testing and request new Pin
    cr set_test0 set_gpio_st clr_adieu
;
: test_1 ( -- ) \ Set Pin High
    gpio @
    high_GPIO
    clr_test0
;
: test_2 ( -- ) \ Set Pin Low
    gpio @
    low_GPIO
    clr_test0
;
: test_3 ( -- ) \ Blink Pin once
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

: init_test ( -- ) \ clear adieu and testing states, set Pin state and request Pin
    erase_pad set_gpio_st clr_adieu clr_test0
    cr .enter_Pin
;

: init_gpio ( n -- ) \ initialize GPIO to be F5 and an output, initial state not saved
    cr
    Pin @ .Pin_UT .
    dup gpio !
    dup .GPIO_UT .
    dup GPIO_F5 GPIO_OUT
    set_gpio_st
;

: valid_GPIO? ( pin -- f GP ) \ return True GP if valid GPIO pin
    dup
    PIN2GP DUP $80 and
    if drop error_Pin
    else swap Pin ! init_gpio
    then
;

: test_Pin ( -- )
    .Pin_range
    begin
        .Test_range
        begin
            init_test
            ctoPin
            if valid_GPIO?
            else adieu?
                if adieu
                else error_input
                then
            then
            Pin_state?
        until
            test0_state? not
            if get_test
            then
        adieu_state?
    until
    check_stack
;
