forgetram
\ graph program from pg 12 Forth:Text and Reference
: .X ." X" ; ( The character to be printed. )
: BAR ( n -- ) 0 DO .X LOOP CR ; ( Plot a bar of X )
: LIMITBAR ( n -- ) DUP 85 > IF DROP 85 THEN BAR ; ( BAR max is 85 )
: GRAPH ( n1 n2 n3 ... -- ) CR DEPTH 0 DO LIMITBAR LOOP ; ( Show graph )

\ Example 10 20 30 40 50 40 30 20 10 GRAPH 

