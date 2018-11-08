#include "Config.txt"

#if Bluedot_Manual_Language==Bluedot_Manual_Language_English
	#include "Language_English\01_Header.txt"
	#include "Language_English\02_Introduction.txt"
	#include "Language_English\03_Tuning.txt"
	#ifdef HoldTuning
		#include "Language_English\04_HoldTuning.txt"
	#endif
	#include "Language_English\05_ManualTuning.txt"
	#ifdef HoldTuning
		#include "Language_English\06_HoldManualTuning.txt"
	#endif
	#ifdef NumericKeypadSearch
		#include "Language_English\10_NumericKeypad.txt"
	#endif
	#include "Language_English\07_Closing.txt"
#endif

#if Bluedot_Manual_Language==Bluedot_Manual_Language_German
	#include "Language_German\01_Header.txt"
	#include "Language_German\02_Introduction.txt"
	#include "Language_German\03_Tuning.txt"
	#ifdef HoldTuning
		#include "Language_German\04_HoldTuning.txt"
	#endif
	#include "Language_German\05_ManualTuning.txt"
	#ifdef HoldTuning
		#include "Language_German\06_HoldManualTuning.txt"
	#endif
	#ifdef NumericKeypadSearch
		#include "Language_German\10_NumericKeypad.txt"
	#endif
	#include "Language_German\07_Closing.txt"
#endif

