namespace VectorPermutationTests
{
    public interface IVectorService
    {
        int[] NextPermutation(int[] vec);
        bool IsValid(int[] vec);
    }
}