	function setTime(x)
	{
			var date = new Date();
			var yy = date.getYear();
			var MM = date.getMonth()+1;
			var dd = date.getDate();
			x.value = yy + "-" +  MM + "-" + dd;
	}
	
	function justNumber(e) 
	{ 
		var key = window.event ? e.keyCode : e.which;
		if(key > 47 && key < 58 || key == 8 || key == 0 || key == 45)
			return true;
		return false;
	} 

    function checkPrice(e,str) 
    { 
		var key = window.event ? e.keyCode:e.which;
		if( key == 8 || key == 0 )
			return true;
        if (key > 47 && key < 58 || key == 46) 
        {
        	if(key == 46)
        	{
        		if(str.indexOf(".")>-1 || str.length==0)
        			return false;
        		return true;
        	}
        	else
        	{   
        		if(str.indexOf(".")!=-1 && str.length-str.indexOf(".")>3)	
	            	return false; 
	            return true;
            }
        }
        else 
            return false; 
    }
    
	function isIE(){
		try
		{
			if (window.navigator.userAgent.toLowerCase().indexOf("msie")>=1) 
				return true; 
			else 
				return false; 
		}
		catch (e)
		{
			try
			{
				return window.event? true: false;
			}
			catch (e2)
			{
				return true;
			}
		}
	} 