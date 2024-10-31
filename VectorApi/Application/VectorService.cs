using VectorPermutationTests;

namespace VectorApi.Application
{
    public class VectorService : IVectorService
    {
        public bool IsValid(int[] vec)
        {
            int vecSize = vec.Length;
            if (vecSize < 1 || vecSize > 100)
                return false;

            //foreach (var num in vec)
            //{
            //    if (!(int.TryParse(num.ToString().Trim(), out int number)
            //        || number < 0 || number > 100))
            //        return false;
            //}

            foreach (int num in vec)
            {
                if (num < 0 || num > 100)
                    return false;
            }

            return true;
        }

        public int[] NextPermutation(int[] vec)
        {
            int vecSize = vec.Length;
            int i = vecSize - 2;

            for (; i >= 0; i--)
            {
                if (vec[i + 1] > vec[i])
                    break;
            }

            if (i >= 0)
            {
                int j = vecSize - 1;
                while (j > i + 1 && vec[j] <= vec[i])
                {
                    j--;
                }

                Interchange(i, j, vec);

                for (int start = i + 1, end = vecSize - 1; start < end; start++, end--)
                {
                    Interchange(start, end, vec);
                }
            }
            else
            {
                Array.Sort(vec);
            }

            return vec;
        }

        private void Interchange(int index1, int index2, int[] array)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
