
using FluentAssertions;
using VectorApi.Application;


namespace VectorPermutationTests
{
    public class VectorServiceTests
    {

        [Fact]
        public void GivenAValidVector_ShouldReturnItsNextPermutation()
        {
            var vectorService = new VectorService();
            int[] vector1 = [1, 2, 3];
            int[] vector2 = [1, 1, 5];
            int[] vector3 = [3, 2, 1];

            var vectorPermutation1 = vectorService.NextPermutation(vector1);
            var vectorPermutation2 = vectorService.NextPermutation(vector2);
            var vectorPermutation3 = vectorService.NextPermutation(vector3);

            vectorPermutation1.Should().Equal([1, 3, 2]);
            vectorPermutation2.Should().Equal([1, 5, 1]);
            vectorPermutation3.Should().Equal([1, 2, 3]);
        }

        [Fact]
        public void GivenAnInvalidLengthVector_ShouldReturnFalse()
        {
            var vectorService = new VectorService();
            int[] vector1 = [];
            int[] vector2 = new int[101];

            var isValid1 = vectorService.IsValid(vector1);
            var isValid2 = vectorService.IsValid(vector2);

            isValid1.Should().BeFalse();
            isValid2.Should().BeFalse();
        }

        [Fact]
        public void GivenAnInvalidVectorNumber_ShouldReturnFalse()
        {
            var vectorService = new VectorService();
            int[] vector1 = [-1];
            int[] vector2 = [101];


            var isValid1 = vectorService.IsValid(vector1);
            var isValid2 = vectorService.IsValid(vector2);

            isValid1.Should().BeFalse();
            isValid2.Should().BeFalse();
        }
    }
}
