var verifyCodeDate = new Date();
var currentDateStr = ""+verifyCodeDate.getYear() + verifyCodeDate.getMonth() + verifyCodeDate.getDay()
   + verifyCodeDate.getHours() + verifyCodeDate.getMinutes() + verifyCodeDate.getSeconds()
   + verifyCodeDate.getMilliseconds();
function refreshVerifyCodeHtml(id) {
  var d = new Date();
  var s = "<img style=\"cursor:pointer\" onclick=\"refreshVerifyCodeHtml('"
         + id +"')\" src=\"Utilities/VerifyCode.aspx?" + d.getYear() + d.getMonth()
         + d.getDay() + d.getHours() + d.getMinutes() + d.getSeconds() + d.getMilliseconds()
         + "&currentDateStr="+currentDateStr+"\">" + " <input type=\"hidden\" name=\"currentDateStr\" id=\"currentDateStr\" value=\""+currentDateStr+"\">";
  document.getElementById(id).innerHTML = s;
  //<span style=\"cursor:pointer\" onclick=\"refreshVerifyCodeHtml('" + id +"')\">¿´²»Çå</span>
}