using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Server.Middleware
{
    /// <summary>
    /// This middleware is for debug purposes only.
    /// Modify this class to help you debug any errors with the request or response.
    /// </summary>
    public class DebugMiddleware
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// The middleware API will inject the next middleware into our constructor.
        /// </summary>
        /// <param name="next">Next middleware to be called.</param>
        public DebugMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// This method will be called whenever we receive any HTTP request.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task Invoke(HttpContext context)
        {
            // Log each request to the console.
            string request = $"Received request: {context.Request.Method} {context.Request.Path}";
            Console.WriteLine(request);

            // Log each response right before it gets sent out.
            context.Response.OnStarting(() =>
            {
                string reponse = $"Sent response code: {context.Response.StatusCode}";
                Console.WriteLine(reponse);
                return Task.CompletedTask;
            });

            // Call the next middleware.
            return next(context);
        }
    }
}