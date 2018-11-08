#!/bin/sh
#clear

# param1 is target, param2 is output-file

NoOfParams="0"
if [ $1 ]; then 
	NoOfParams="1" 
fi 

if [ $2 ]; then 
	NoOfParams="2" 
fi 

case $NoOfParams in 
   1)
      gcc -E -C -P -Wall -D $1 _RadioManual.cpp
      ;;
   2)
      gcc -E -C -P -Wall -D $1 -o $2 _RadioManual.cpp
      ;;
   *)
      echo "No Radio specified. Try again!"
      echo "1st parameter specifies radio (e.g. DARMSTADT)" 
      echo "2nd parameter specifies filename for output (e.g. Darmstadt.html)" 
      ;;
esac 