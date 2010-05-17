using System;
using System.Linq.Expressions;
using MbUnit.Framework;
using Should.Extensions.AssertExtensions;
using UITesting.Models;

namespace UITesting.Tests
{
    [TestFixture]
    public class UINameHelperTester
    {
        [Test]
        public void should_build_name_from_typed_expression()
        {
            UINameHelper.BuildNameFrom<ProductForm>(f => f.Id).ShouldEqual(
                "Id");
        }

        [Test]
        public void Should_build_name_from_basic_expression()
        {
            Expression<Func<ProductForm, object>> expression = f => f.Id;
            UINameHelper.BuildNameFrom(expression).ShouldEqual("Id");
        }

        [Test]
        public void Should_build_name_from_indexed_expression()
        {
            Expression<Func<LargeProductForm, object>> expression =
                f => f.AllProducts[5].Model;
            UINameHelper.BuildNameFrom(expression).ShouldEqual(
                "AllProducts[5].Model");
        }

        public class LargeProductForm
        {
            public int Id { get; set; }
            public ProductForm[] AllProducts { get; set; }
        }
    }
}