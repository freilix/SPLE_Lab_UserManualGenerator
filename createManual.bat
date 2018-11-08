@ECHO OFF
rem param1 is target, param2 is output-file (e.g.)
IF NOT "%2"=="" GOTO 2Params

IF NOT "%1"=="" GOTO 1Params

GOTO 0Params

:0Params
  ECHO No Radio specified. Try again!
  ECHO 1st parameter specifies radio (e.g. DARMSTADT)
  ECHO 2nd parameter specifies filename for output (e.g. Darmstadt.html)
GOTO End1

:1Params
@ECHO ON
  gcc -E -C -P -Wall -D %1 _RadioManual.cpp
@ECHO OFF
GOTO End1

:2Params
@ECHO ON
  gcc -E -C -P -Wall -D %1 -o %2 _RadioManual.cpp
@ECHO OFF
GOTO End1

:End1