/*
	This is the source code for the validation routines. Please feel free to augment, fix, change, use where-ever you want.
	
	***Do Not Delete***
	File: validate.js
	Author: Chris Davey
	Version: 1.0
	Email: chris.davey@chemlock.co.uk
	Web: www.chemlock.co.uk
	***End Do Not Delete***
	
	Please visit my site for more info, examples and versions (www.chemlock.co.uk)	
*/

//Controls that require validating can be put into this object
function ControlDetail ( elementid, required, maxlength, minlength, email, decimal, nonnegdecimal, ipaddress)
{
 this.elementid = elementid;
 this.required = required;
 this.maxlength = maxlength;
 this.minlength = minlength;
 this.email = email;
 this.decimal = decimal;
 this.nonnegdecimal = nonnegdecimal;
 this.ipaddress = ipaddress;
}

//** All Validation Functions **
function ContainsValue(element)
{
	return document.getElementById(element).value.length != 0;
}

function IsOverMaxLength(element,maxlength)
{
	//return document.getElementById(element).value.length > maxlength;
	 
    // replace将符合此正则的字符串替换成指定字符 然后在计算长度  汉字为两个长度
    return document.getElementById(element).value.replace(/[^\x00-\xff]/g,"**").length > maxlength; 
 
}

function IsUnderMinLength(element,minlength)
{
	
	//return document.getElementById(element).value.length < minlength;
	return document.getElementById(element).value.replace(/[^\x00-\xff]/g,"**").length < minlength;
}

function RegExTest(element,expression)
{
	return element.value.match(expression) != null;
}

function IsEmail(element)
{
	var emailRE = "([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})";
	return RegExTest(element,emailRE);
}

function IsDecimal(element)
{
	var decimalRE = "^(\\+|-)?[0-9][0-9]*(\\.[0-9]*)?$";
	return RegExTest(element,decimalRE);
}

function IsNonNegDecimal(element)
{
	var nonnegdecimalRE = "^[0-9][0-9]*(\\.[0-9]*)?$";
	return RegExTest(element,nonnegdecimalRE);
}
//** End All Validation Functions **

//** Main Validation Routine **

function Validate(controlsToValidate)
{
    valid = true;
	
	var message = "提示:\n\n";
	
	for(var i = 0;i < controlsToValidate.length;i++)
	{
		if(controlsToValidate[i].required == 1)
		{
		//Validate that a value has been entered
			if(ContainsValue(controlsToValidate[i].elementid) == false)
			{
				valid = false;
				message += "【" + document.getElementById(controlsToValidate[i].elementid).title + "】为必填内容.\n";
			}
		}
		
		if(controlsToValidate[i].maxlength != -1)
		{
		//Validate that the value is not over max
			if(IsOverMaxLength(controlsToValidate[i].elementid, controlsToValidate[i].maxlength) == true)
			{
				valid = false;
				message +=  "【" + document.getElementById(controlsToValidate[i].elementid).title + "】内容太长.\n";
			}
		}
		
		if(controlsToValidate[i].minlength != -1)
		{

		//Validate that the value is not under min
			if(IsUnderMinLength(controlsToValidate[i].elementid, controlsToValidate[i].minlength) == true)
			{
				valid = false;
				message +=  "【" + document.getElementById(controlsToValidate[i].elementid).title + "】内容太短.\n";
			}
		}
		
		if(controlsToValidate[i].email == 1)
		{
		//Validate that the value is an email
			if(IsEmail(document.getElementById(controlsToValidate[i].elementid)) == false)
			{
				valid = false;
				message +=  "【" + document.getElementById(controlsToValidate[i].elementid).title + "】不是一个有效的Email地址.\n";
			}
		}
		
		if(controlsToValidate[i].decimal == 1)
		{
		//Validate that the value is decimal
			if(IsDecimal(document.getElementById(controlsToValidate[i].elementid)) == false)
			{
				valid = false;
				message +=  "【" + document.getElementById(controlsToValidate[i].elementid).title + "】非数值.\n";
			}
		}
		
		if(controlsToValidate[i].nonnegdecimal == 1)
		{
		//Validate that the value is decimal
			if(IsNonNegDecimal(document.getElementById(controlsToValidate[i].elementid)) == false)
			{
				valid = false;
				message += "【" + document.getElementById(controlsToValidate[i].elementid).title + "】非正数值.\n";
			}
		}
		
		if(controlsToValidate[i].ipaddress == 1)
		{
		//Validate that the value is decimal
			if(IsIpAddress(document.getElementById(controlsToValidate[i].elementid)) == false)
			{
				valid = false;
				message += "【" + document.getElementById(controlsToValidate[i].elementid).title + "】不是有效的IP地址.\n";
			}
		}
	}

    if (valid == false)
    {
		alert (message);
	}
    return valid;
}

//** END Main Validation Routine **