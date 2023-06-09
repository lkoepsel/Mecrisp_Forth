\ A microsecond time counter

$40054000 constant TIMEHW
$40054004 constant TIMELW
$40054008 constant TIMEHR
$4005400C constant TIMELR
$40054024 constant TIMERAWH
$40054028 constant TIMERAWL

: cycles ( -- u ) TIMERAWL @ ;

: delay-cycles ( cycles -- )
  cycles ( cycles start )
  begin
    pause
    2dup ( cycles start cycles start )
    cycles ( cycles start cycles start current )
    swap - ( cycles start cycles elapsed )
    u<=
  until
  2drop
;

: us ( u -- )        delay-cycles ;
: ms ( u -- ) 1000 * delay-cycles ;
