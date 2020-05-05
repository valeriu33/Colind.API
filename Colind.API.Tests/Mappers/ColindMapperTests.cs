using Colind.API.Mappers;
using Colind.API.Persistence.Entities;
using NUnit.Framework;
using DeepEqual.Syntax;
using Colind.API.DtoModels;
using System.Collections.Generic;

namespace Colind.API.Tests.Mappers
{
    [TestFixture]
    public class ColindMapperTests
    {
        private ColindMapper colindMapper;

        private ColindEntity testEntity = new ColindEntity
        {
            Title = "Title",
            Text = "Text"
        };

        private ColindDto expectedResult = new ColindDto
        {
            Title = "Title",
            Text = "Text"
        };

        public ColindMapperTests()
        {
            colindMapper = new ColindMapper();
        }

        [Test]
        public void ToDto_NullAuthor_NullTags_Test()
        {
            // Arrange


            // Act
            var result = colindMapper.ToDto(testEntity);

            // Assert
            result.ShouldDeepEqual(expectedResult);
        }

        [Test]
        public void ToDto_NullTags_Test()
        {
            // Arrange
            testEntity.AuthorFullName = "Author";
            expectedResult.Author = "Author";

            // Act
            var result = colindMapper.ToDto(testEntity);

            // Assert
            result.ShouldDeepEqual(expectedResult);
        }

        [Test]
        public void ToDto_FullEntity_Test()
        {
            // Arrange
            testEntity.AuthorFullName = "Author";
            expectedResult.Author = "Author";

            testEntity.ColindTags = new List<ColindTagEntity>
            {
                new ColindTagEntity
                {
                    TagName = "Tag1"
                },
                new ColindTagEntity
                {
                    TagName = "Tag2"
                }
            };

            expectedResult.Tags = new List<string> { "Tag1", "Tag2" };

            // Act
            var result = colindMapper.ToDto(testEntity);

            // Assert
            result.ShouldDeepEqual(expectedResult);
        }
    }
}