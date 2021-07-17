using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 五子棋_v2
{
	/// <summary>
	/// 一个神经元,包含权重偏置
	/// </summary>
	class neuron
	{
		/// <summary>
		/// 权重
		/// </summary>
		public double[] weight;

		/// <summary>
		/// 偏置
		/// </summary>
		public double bias;

		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="w"></param>
		/// <param name="b"></param>
		/// <param name="num">input数量</param>
		public neuron(double[] w, double b)
		{
			for (int i = 0; i < w.Length; i++)
				weight[i] = w[i];

			bias = b;
		}

		/// <summary>
		/// 加和
		/// </summary>
		/// <param name="inputs">上层输入[num]</param>
		/// <returns></returns>
		public double sum(double[] inputs)
		{
			double sum = 0;

			for (int i = 0; i < inputs.Length; i++)
				sum += (weight[i] * inputs[i]);

			return sum + bias;
		}

		/// <summary>
		/// 接口函数
		/// </summary>
		/// <param name="inputs">上一层Output数组</param>
		/// <returns>double输出值</returns>
		public double output(double[] inputs)
		{
			return Leacky_ReLU(sum(inputs));
		}

		/// <summary>
		/// 激活函数Leacky_ReLU
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public static double Leacky_ReLU(double x)
		{
			if (x >= 0)
				return x;
			else
				return 0.05 * x;
		}

		/// <summary>
		/// Leacky_ReLU导数
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public static double DerivativeOfLeacky_ReLU(double x)
		{
			if (x >= 0)
				return 1;
			else
				return 0.05;
		}

	}
}
