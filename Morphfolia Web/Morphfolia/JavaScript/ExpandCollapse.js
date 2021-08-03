/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.   */

// JScript File

function ExpandCollapseThing(tr)
{    
    if(tr)
    {
        if(tr.parentElement.rows.length > 1)
        {
            if(tr.parentElement.rows[1].style.display == 'none')
            {
                for(r = 1; r < tr.parentElement.rows.length; r++)
                {
                    tr.parentElement.rows[r].style.display = 'inline';
                }
            }
            else
            {
                for(r = 1; r < tr.parentElement.rows.length; r++)
                {
                    tr.parentElement.rows[r].style.display = 'none';
                }
            }
        }
    }
}