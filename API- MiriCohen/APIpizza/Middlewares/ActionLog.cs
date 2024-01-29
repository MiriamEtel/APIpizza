using System.Diagnostics;
using System.Globalization;
using fileService;
using System.Text.Json;

namespace APIpizza.Middlewares
{
    public class ActionLogMiddleWare
    {
        private readonly RequestDelegate _next;
        private IfileService<string> _rwr;

        public ActionLogMiddleWare(RequestDelegate next )
    {
        _next=next;
    }

    public async Task InvokeAsync(HttpContext context, IfileService<string> rwr)
    {
 try{
      _rwr=rwr;
      _rwr.FileName="log.txt";
      string mr = context.Request.Method;
      string pr = context.Request.Path;
      string ptc= context.Request.Protocol;
      if(pr!="/index.html" && pr!="/favicon.ico"){
         string xr="the request:  date time: "+DateTime.Now +" method: "+mr +" path: "+pr+" protocol: "+ptc;
        _rwr.WriteLog(xr);
    }
    
    await _next(context);
    _rwr.FileName="log.txt";
    int ss = context.Response.StatusCode;
     if(pr!="/index.html" && pr!="/favicon.ico"){
        string xs="the response:  date time: "+DateTime.Now +" status code: " +ss;
        _rwr.WriteLog(xs);
    }
  }
   catch(Exception ex)
   {
    throw ex;
   }
    }
}
}