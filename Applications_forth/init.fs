\ words required for stair-stepping
\ both need to stay in flash, however don't....
compiletoflash
: emit-crlf ( c -- ) dup 10 = if 13 serial-emit then serial-emit ;
: INIT ['] emit-crlf hook-emit ! ;
compiletoram