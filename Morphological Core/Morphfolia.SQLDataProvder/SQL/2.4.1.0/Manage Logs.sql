/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */

SELECT Count(*) FROM [Log]
--DELETE FROM [Log] WHERE LogId < 39000
SELECT Count(*) FROM [Log] 
SELECT TOP 10 * FROM [Log] ORDER BY LogId DESC


SELECT Count(*) FROM [HttpLog]
--DELETE FROM [HttpLog] WHERE LogId < 39000
SELECT Count(*) FROM [HttpLog] 
SELECT TOP 10 * FROM [HttpLog] ORDER BY LogId DESC

