using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 五子棋_v2
{
	/// <summary>
	/// 神经网络
	/// </summary>
	class neuronNetwork
	{
		/// <summary>
		/// 361个棋盘状态:输入层
		/// </summary>
		public double[] inputs = new double[361];
		/// <summary>
		/// 第一隐含层:8个
		/// </summary>
		public neuron[] neuronsL1 = new neuron[8];
		/// <summary>
		/// 第二隐含层:8个
		/// </summary>
		public neuron[] neuronsL2 = new neuron[8];
		/// <summary>
		/// 输出层:2个
		/// </summary>
		public neuronTanh[] neuronsOutput = new neuronTanh[2];

		/// <summary>
		/// constructor:初始化权重偏置
		/// </summary>
		/// <param name="L1weight">第一隐含层8*361个权重,由8个361元数组构成</param>
		/// <param name="L1bias">第一隐含层8个偏置</param>
		/// <param name="L2weight">第二隐含层8*8个权重,由8个8元数组构成</param>
		/// <param name="L2bias">第二隐含层8个偏置</param>
		/// <param name="Outputweight">输出层2*8个权重,由2个8元数组构成</param>
		/// <param name="Outputbias">输出层2个偏置</param>
		/// <param name="Input"></param>
		public neuronNetwork(
			double[][] L1weight, double[] L1bias,
			double[][] L2weight, double[] L2bias, 
			double[][] Outputweight, double[] Outputbias)
        {
			int i = 0;
			for (i = 0; i < 8; i++)
				neuronsL1[i] = new neuron(L1weight[i], L1bias[i]);
			for (i = 0; i < 8; i++)
				neuronsL2[i] = new neuron(L2weight[i], L2bias[i]);
			for (i = 0; i < 2; i++)
				neuronsOutput[i] = new neuron(Outputweight[i], Outputbias[i]);
		}

		/// <summary>
		/// 调用此函数返回坐标
		/// </summary>
		/// <param name="Input">当前局势</param>
		/// <returns>落子点最终坐标</returns>
		public Point response(double[] Input)
		{
			// 设置inputs
			int i = 0;
			foreach (int e in Input)
			{
				inputs[i] = e;
				i++;
			}

			// 计算第一层输出
			double[] Out1 = new double[8];
			for (i = 0; i < 8; i++)
				Out1[i] = neuronsL1[i].output(inputs);

			// 计算第二层输出
			double[] Out2 = new double[8];
			for (i = 0; i < 8; i++)
				Out2[i] = neuronsL2[i].output(Out1);

			// 第三层输出
			return new Point(Convert.ToInt32(19 * (0.5 * neuronsOutput[1].output(Out2) + 0.5)),
				Convert.ToInt32(19 * (0.5 * neuronsOutput[2].output(Out2) + 0.5)));
		}
	}
}
