﻿select SUM(case when Stat='22' OR Stat='33' OR Stat='44'OR Stat='55'OR Stat='66'OR Stat='77'OR Stat='88' then 1 else 0 end) as JamClear FROM TblInOut WHERE   DTIn  between  '2016/09/14'  and   '2016/09/15'  