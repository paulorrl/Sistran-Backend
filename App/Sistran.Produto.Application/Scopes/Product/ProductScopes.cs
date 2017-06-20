using Sistran.Kernel.Domain.CQSeparation.Command;
using Sistran.Kernel.Domain.ValueObjects.Resource;
using Sistran.Kernel.Domain.ValueObjects.Validation;

namespace Sistran.Produto.Application.Scopes.Product
{
    internal static class ProductScopes
    {
        internal static void ValidationProductId(int id)
        {
            AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertArgumentGreater(valueCompare: id, valueReference: 0, message: ProductMessagesValidation.ProductId)
                );
        }

        internal static void ValidationNewProduct(NewProductCommand command)
        {
            AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertArgumentLength(stringValue: command.Nome, minimum: 3, maximum: 20, message: ProductMessagesValidation.ProductName),
                    AssertionConcern.AssertArgumentLength(stringValue: command.Descricao, minimum: 3, maximum: 100, message: ProductMessagesValidation.ProductDescription),
                    AssertionConcern.AssertArgumentGreater(valueReference: command.Preco, valueCompare: 0, message: ProductMessagesValidation.ProductPrice)
                );
        }

        internal static void ValidationUpdateProduct(UpdateProductCommand command)
        {
            AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertArgumentGreater(valueCompare: command.Id, valueReference: 0, message: ProductMessagesValidation.ProductId),
                    AssertionConcern.AssertArgumentLength(stringValue: command.Nome, minimum: 3, maximum: 20, message: ProductMessagesValidation.ProductName),
                    AssertionConcern.AssertArgumentLength(stringValue: command.Descricao, minimum: 3, maximum: 100, message: ProductMessagesValidation.ProductDescription),
                    AssertionConcern.AssertArgumentGreater(valueReference: command.Preco, valueCompare: 0, message: ProductMessagesValidation.ProductPrice)
                );
        }

        internal static void ValidationRemoveProduct(int id)
        {
            AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertArgumentGreater(valueCompare: id, valueReference: 0, message: ProductMessagesValidation.ProductId)
                );
        }
    }
}