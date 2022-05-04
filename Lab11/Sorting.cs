using System;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Lab11
{
    public class Sorting
    {
        public static int[] MergeSorting(int[] massive)
        {
            if (massive.Length == 1)
                return massive;
            int mid_point = massive.Length / 2;
            return Merge(MergeSorting(massive.Take(mid_point).ToArray()), MergeSorting(massive.Skip(mid_point).ToArray()));
        }
        public static int[] Merge(int[] mass1, int[] mass2)
        {
            int a = 0, b = 0;
            int[] merged = new int[mass1.Length + mass2.Length];
            for (int i = 0; i < merged.Length; i++)
            {
                if (b < mass2.Length && a < mass1.Length)
                    if (mass1[a] > mass2[b] && b < mass2.Length)
                        merged[i] = mass2[b++];
                    else
                        merged[i] = mass1[a++];
                else
                    if (b < mass2.Length)
                        merged[i] = mass2[b++];
                    else
                        merged[i] = mass1[a++];
            }
            return merged;
        }
        /*****Please include following Assemblies*******/
// Microsoft.VisualBasic (in Microsoft.VisualBasic.dll)
/***********************************************/

/*****Please use following namespaces*****/
// Microsoft.VisualBasic.CompilerServices
/*****************************************/

	private static bool IsAscending(string A, string B)
	{
		return (StringType.StrCmp(A, B, false) <= 0);
	}

	private static void UP(ref int IA, ref int IB, ref int temp)
	{
		temp = IA;
		IA += IB + 1;
		IB = temp;
	}

	private static void DOWN(ref int IA, ref int IB, ref int temp)
	{
		temp = IB;
		IB = IA - IB - 1;
		IA = temp;
	}

	private static int q, r, p, b, c, r1, b1, c1;
	private static string[] A;

	private static void Sift()
	{
		int r0, r2, temp = 0;
		string t;
		r0 = r1;
		t = A[r0];

		while (b1 >= 3)
		{
			r2 = r1 - b1 + c1;

			if (!IsAscending(A[r1 - 1], A[r2]))
			{
				r2 = r1 - 1;
				DOWN(ref b1, ref c1, ref temp);
			}

			if (IsAscending(A[r2], t))
			{
				b1 = 1;
			}
			else
			{
				A[r1] = A[r2];
				r1 = r2;
				DOWN(ref b1, ref c1, ref temp);
			}
		}

		if (Convert.ToBoolean(r1 - r0))
			A[r1] = t;
	}

	private static void Trinkle()
	{
		int p1, r2, r3, r0, temp = 0;
		string t;
		p1 = p;
		b1 = b;
		c1 = c;
		r0 = r1;
		t = A[r0];

		while (p1 > 0)
		{
			while ((p1 & 1) == 0)
			{
				p1 >>= 1;
				UP(ref b1, ref c1, ref temp);
			}

			r3 = r1 - b1;

			if ((p1 == 1) || IsAscending(A[r3], t))
			{
				p1 = 0;
			}
			else
			{
				--p1;

				if (b1 == 1)
				{
					A[r1] = A[r3];
					r1 = r3;
				}
				else
				{
					if (b1 >= 3)
					{
						r2 = r1 - b1 + c1;

						if (!IsAscending(A[r1 - 1], A[r2]))
						{
							r2 = r1 - 1;
							DOWN(ref b1, ref c1, ref temp);
							p1 <<= 1;
						}
						if (IsAscending(A[r2], A[r3]))
						{
							A[r1] = A[r3]; r1 = r3;
						}
						else
						{
							A[r1] = A[r2];
							r1 = r2;
							DOWN(ref b1, ref c1, ref temp);
							p1 = 0;
						}
					}
				}
			}
		}

		if (Convert.ToBoolean(r0 - r1))
			A[r1] = t;

		Sift();
	}

	private static void SemiTrinkle()
	{
		string T;
		r1 = r - c;

		if (!IsAscending(A[r1], A[r]))
		{
			T = A[r];
			A[r] = A[r1];
			A[r1] = T;
			Trinkle();
		}
	}

	public static void SmoothSort(string[] Aarg, int N)
	{
		int temp = 0;
		A = Aarg;
		q = 1;
		r = 0;
		p = 1;
		b = 1;
		c = 1;

		while (q < N)
		{
			r1 = r;
			if ((p & 7) == 3)
			{
				b1 = b;
				c1 = c;
				Sift();
				p = (p + 1) >> 2;
				UP(ref b, ref c, ref temp);
				UP(ref b, ref c, ref temp);
			}
			else if ((p & 3) == 1)
			{
				if (q + c < N)
				{
					b1 = b;
					c1 = c;
					Sift();
				}
				else
				{
					Trinkle();
				}

				DOWN(ref b, ref c, ref temp);
				p <<= 1;

				while (b > 1)
				{
					DOWN(ref b, ref c, ref temp);
					p <<= 1;
				}

				++p;
			}

			++q;
			++r;
		}

		r1 = r;
		Trinkle();

		while (q > 1)
		{
			--q;

			if (b == 1)
			{
				--r;
				--p;

				while ((p & 1) == 0)
				{
					p >>= 1;
					UP(ref b, ref c, ref temp);
				}
			}
			else
			{
				if (b >= 3)
				{
					--p;
					r = r - b + c;
					if (p > 0)
						SemiTrinkle();

					DOWN(ref b, ref c, ref temp);
					p = (p << 1) + 1;
					r = r + c;
					SemiTrinkle();
					DOWN(ref b, ref c, ref temp);
					p = (p << 1) + 1;
				}
			}
		}
	}
    }
}