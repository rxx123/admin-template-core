using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Extensions.CustomApiVersion;

namespace Extensions
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => {

                //c.SwaggerDoc("v1", new OpenApiInfo
                //{
                //    Version = "v0.1.0",
                //    Title = "RUXING API",
                //    Description = "框架说明文档",
                //    Contact = new OpenApiContact { Name = "RUXING", Email = "ruxingxing@xakcdz.com" }
                //});
                //var basePath = AppContext.BaseDirectory;
                //var xmlPath = Path.Combine(basePath, "admin-template-core3.1.xml");
                //c.IncludeXmlComments(xmlPath, true);

                string ApiName = "";
                //遍历出全部的版本，做文档信息展示
                typeof(ApiVersions).GetEnumNames().ToList().ForEach(version =>
                {
                    c.SwaggerDoc(version, new OpenApiInfo
                    {
                        // {ApiName} 定义成全局变量，方便修改
                        Version = version,
                        Title = $"{ApiName} 接口文档",
                        Description = $"{ApiName} HTTP API " + version,
                        Contact = new OpenApiContact { Name = "admin-template", Email = "Blog.Core@xxx.com"}
                    });
                });
            });
        }
    }
}
