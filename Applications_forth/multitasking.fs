forgetram
\ -----------------------------------------------------------
\   Cooperative Multitasking
\ -----------------------------------------------------------

\ Configuration:

128 cells constant stackspace \ 128 stack elements for every task

\ Internal stucture of task memory:
\  0: Pointer to next task
\  4: Task currently active ?
\  8: Saved stack pointer
\ 12: Handler for Catch/Throw
\  Parameter stack space
\  Return    stack space

false 0 true flashvar-here 4 cells - 4 nvariable boot-task \ Boot task is active, without handler and has no extra stackspace.
boot-task boot-task ! \ For compilation into RAM only

boot-task variable up \ User Pointer
: next-task  ( -- task )    up @ inline ;
: task-state ( -- state )   up @ 1 cells + inline ;
: save-task  ( -- save )    up @ 2 cells + inline ;
: handler    ( -- handler ) up @ 3 cells + inline ;

: (pause) ( stacks fly around )
    [ $B430 h, ]        \ push { r4  r5 } to save I and I'
    rp@ sp@ save-task !  \ save return stack and stack pointer
    begin
      next-task @ up !     \ switch to next running task
    task-state @ until
    save-task @ sp! rp!  \ restore pointers
    unloop ;              \ pop { r4  r5 } to restore the loop registers

: wake ( task -- ) 1 cells +  true swap ! ; \ Wake a random task (IRQ save)
: idle ( task -- ) 1 cells + false swap ! ;  \ Idle a random task (IRQ save)

\ -------------------------------------------------------
\  Round-robin list task handling - do not use in IRQ !
\ -------------------------------------------------------

: stop ( -- ) false task-state ! pause ; \ Stop current task
: multitask  ( -- ) ['] (pause) hook-pause ! ;
: singletask ( -- ) [']  nop    hook-pause ! ;

: task-in-list? ( task -- ? ) \ Checks if a task is currently inside of round-robin list (do not use in IRQ)
  next-task
  begin
    ( Task-Address )
    2dup = if 2drop true exit then
    @ dup next-task = \ Stop when end of circular list is reached
  until
  2drop false
;

: previous ( task -- addr-of-task-before )
  \ Find the task that has the desired one in its next field
  >r next-task begin dup @ r@ <> while @ repeat rdrop
;

: insert ( task -- ) \ Insert a task into the round-robin list
  dup task-in-list?  \ Is the desired task currently linked into ?
  if drop else next-task @ over ! next-task ! then
;

: remove ( task -- ) \ Remove a task from the round-robin list
  dup task-in-list?  \ Is the desired task currently linked into ?
  if dup @ ( task next )
     swap previous ( next previous ) !
  else drop then
;

\ -----------------------------------------
\ Create a new task - do not use in IRQ !
\ -----------------------------------------

: task: ( "name" -- )  stackspace cell+ 2*  4 cells +  buffer: ;

: preparetask ( task continue -- )
  swap >r ( continue R: task )

    \ true  r@ 1 cells + ! \ Currently running
      false r@ 3 cells + ! \ No handler

    r@ 4 cells + stackspace + ( continue start-of-parameter-stack )
      dup   r@ 2 cells + ! \ Start of parameter stack

    dup stackspace + ( continue start-of-parameter-stack start-of-return-stack )
    tuck      ( continue start-of-return-stack start-of-parameter-stack start-of-return-stack )
    2 cells - ( continue start-of-return-stack start-of-parameter-stack start-of-return-stack* ) \ Adjust for saved loop index and limit
    swap  !   ( continue start-of-return-stack ) \ Store the adjusted return stack pointer into the parameter stack
    !         \ Store the desired entry address at top of the tasks return stack

  r> insert
;

: activate ( task --   R: continue -- )
  true over 1 cells + ! \ Currently running
  r> preparetask
;

: background ( task --   R: continue -- )
  false over 1 cells + ! \ Currently idling
  r> preparetask
;

\ --------------------------------------------------
\  Multitasking insight
\ --------------------------------------------------

: tasks ( -- ) \ Show tasks currently in round-robin list
  hook-pause @ singletask \ Stop multitasking as this list may be changed during printout.

  \ Start with current task.
  next-task cr

  begin
    ( Task-Address )
    dup             ." Task Address: " hex.
    dup           @ ." Next Task: " hex.
    dup 1 cells + @ ." State: " hex.
    dup 2 cells + @ ." Stack: " hex.
    dup 3 cells + @ ." Handler: " hex. cr

    @ dup next-task = \ Stop when end of circular list is reached
  until
  drop

  hook-pause ! \ Restore old state of multitasking
;

\ --------------------------------------------------
\  Exception handling
\ --------------------------------------------------

: catch ( x1 .. xn xt -- y1 .. yn throwcode / z1 .. zm 0 )
    [ $B430 h, ]  \ push { r4  r5 } to save I and I'
    sp@ >r handler @ >r rp@ handler !  execute
    r> handler !  rdrop  0 unloop ;

: throw ( throwcode -- )  dup IF
	handler @ 0= IF false task-state ! THEN \ unhandled error: stop task
	handler @ rp! r> handler ! r> swap >r sp! drop r>
	UNLOOP  EXIT
    ELSE  drop  THEN ;

#12 constant red
#11 constant green
#10 constant blue
#9  constant yellow

: init_leds
  led gpio_F5
  led gpio_out
	red gpio_F5
	red gpio_out
	green gpio_F5
	green gpio_out
	blue gpio_F5
	blue gpio_out
	yellow gpio_F5
	yellow gpio_out
;

init_leds

\ blink_on ( n -- ) blinks on-board led n ms
\ requires dict1.fs for constants
\ requires pin13 to be SIO (F5) DS_p258

: blink_on ( n -- ) \ blinks on-board led n ms
  led tog_gpio
  half_sec
  led tog_gpio
  half_sec
;

: blinkred		
red tog_gpio
one_sec
red tog_gpio
one_sec
;	

: blinkgreen		
green tog_gpio
half_sec
green tog_gpio
half_sec
;	

: blinkblue		
blue tog_gpio
qtr_sec
blue tog_gpio
qtr_sec
;	

: blinkyellow		
yellow tog_gpio
tenth_sec
yellow tog_gpio
tenth_sec
;	

task: blinktask
: blink_on& ( -- )
  blinktask activate
    begin  100 blink_on key? until
;

task: blinktask
: blinkyG& ( -- )
  blinktask activate
    begin  blinkgreen again
;

task: blinktask
: blinkyR& ( -- )
  blinktask activate
    begin  blinkred again
;

task: blinktask
: blinkyB& ( -- )
  blinktask activate
    begin  blinkblue again
;

task: blinktask
: blinkyY& ( -- )
  blinktask activate
    begin  blinkyellow again
;

multitask
blinkyR& 
blinkyG& 
blinkyB& 
blinkyY& 
blink_on&
