\ color-term - dictionary for color coding terminal
forgetram

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

: bp fuchsia cr . .s cr black ;
