using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Sistran.API.Attributes;
using Sistran.API.Controlers.Base;
using Sistran.Kernel.Domain.CQSeparation.Command;
using Sistran.Kernel.Domain.ValueObjects.Resource;
using Sistran.Produto.Application.Interface;

namespace Sistran.API.Controlers
{
    [RoutePrefix("api/v1/products")]
    public class ProductController : BaseController
    {
        private readonly IProductApplication _app;

        public ProductController(IProductApplication app)
        {
            _app = app;
        }

        [DeflateCompression]
        [Route(""), HttpGet]
        public Task<HttpResponseMessage> GetProducts()
        {
            try
            {
                var products = _app.GetProducts();
                return CreateResponse(HttpStatusCode.OK, products);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [DeflateCompression]
        [Route("{id}"), HttpGet]
        public Task<HttpResponseMessage> GetById(int id)
        {
            try
            {
                var product = _app.GetById(id);
                return CreateResponse(HttpStatusCode.OK, product);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [DeflateCompression]
        [Route("new"), HttpPost]
        public Task<HttpResponseMessage> New(NewProductCommand command)
        {
            try
            {
                _app.AddProduct(command);
                return CreateResponse(HttpStatusCode.OK, new { product = command, message = ProductsMessages.NewProduct });
            }
            catch (Exception e)
            {
                return CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [DeflateCompression]
        [Route("update"), HttpPost]
        public Task<HttpResponseMessage> Update(UpdateProductCommand command)
        {
            try
            {
                _app.UpdateProduct(command);
                return CreateResponse(HttpStatusCode.OK, new { product = command, message = ProductsMessages.UpdatedProduct });
            }
            catch (Exception e)
            {
                return CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("delete"), HttpDelete]
        public Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                _app.RemoveProduct(id);
                return CreateResponse(HttpStatusCode.OK, new { message = ProductsMessages.RemovedProduct });
            }
            catch (Exception e)
            {
                return CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}