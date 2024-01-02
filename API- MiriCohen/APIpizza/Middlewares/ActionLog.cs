using System.Diagnostics;
using System.Globalization;
using fileService;
using System.Text.Json;

namespace APIpizza.Middlewares
{
    public class ActionLogMiddleWare
    {
        private readonly RequestDelegate _next;
        readonly IfileService <string> _rwr;

        public ActionLogMiddleWare(RequestDelegate next,IfileService <string> rwr)
    {
        _next=next;
        _rwr=rwr;
    }

    public async Task InvokeAsync (HttpContext context)
    {
        DateTime dr=DateTime.Now;
        string mr=context.Request.Method;
        string pr=context.Request.Path;
        string prtc=context.Request.Protocol;
        if (pr!="/index.html"&& pr!="/favcion.ico"){
            string xr="the request: date time:"+dr+"method:"+mr+"path:"+pr+"protocol"+prtc;
        _rwr.Write(xr,Path.Combine(Environment.CurrentDirectory,"File","log.txt"));
        }

        //calling the next delegate/Middleware in the pipeline
     await  _next(context);
     DateTime ds=DateTime.Now;
     int ss =context.Response.StatusCode;
     if (pr!="/index.html"&& pr!="/favcion.ico"){
        string xs="the response: date time:"+ds+"Status code:"+ss;
        _rwr.Write(xs,Path.Combine(Environment.CurrentDirectory,"File","log.txt"));
     }
    }
    }
}