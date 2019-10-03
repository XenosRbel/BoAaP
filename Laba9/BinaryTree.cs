using System;
using System.Collections.Generic;
using System.Text;

namespace Laba9
{
	public class BinaryTree<T> where T : IComparable<T>
	{
		public BinaryTree<T> Parent { get; set; }
		public BinaryTree<T> Left { get; set; }
		public BinaryTree<T> Right { get; set; }
		public T Val { get; set; }

		public BinaryTree(T val, BinaryTree<T> parent)
		{
			Val = val;
			Parent = parent;
		}

		public void Add(T val)
		{
			if (val.CompareTo(Val) < 0)
			{
				if (Left == null)
				{
					Left = new BinaryTree<T>(val, this);
				}
				else if (Left != null)
				{
					Left.Add(val);
				}
			}
			else
			{
				if (Right == null)
				{
					Right = new BinaryTree<T>(val, this);
				}
				else if (Right != null)
				{
					Right.Add(val);
				}
			}
		}

		private BinaryTree<T> Search(BinaryTree<T> tree, T val)
		{
			if (tree == null) return null;

			switch (val.CompareTo(tree.Val))
			{
				case 1: 
					return Search(tree.Right, val);
				case -1:
					return Search(tree.Left, val);
				case 0: 
					return tree;
				default: 
					return null;
			}
		}

		public BinaryTree<T> Search(T val)
		{
			return Search(this, val);
		}

		public int Count(ref int c)
		{
			if ((Left != null) && (Right != null)) c++;
			if (this.Left != null) this.Left.Count(ref c);
			if (this.Right != null) this.Right.Count(ref c);
			return c;
		}

		#region Print

		public void PrintTree()
		{
			PrintTree(this);
		}

		private void PrintTree(BinaryTree<T> startNode, string indent = "", Side? side = null)
		{
			if (startNode != null)
			{
				var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
				Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Val}");
				indent += new string(' ', 3);

				PrintTree(startNode.Left, indent, Side.Left);
				PrintTree(startNode.Right, indent, Side.Right);
			}
		}
		#endregion

		public bool Remove(T val)
		{
			//Проверяем, существует ли данный узел
			BinaryTree<T> tree = Search(val);
			if (tree == null)
			{
				return false;
			}
			BinaryTree<T> curTree;

			//Если удаляем корень
			if (tree == this)
			{
				if (tree.Right != null)
				{
					curTree = tree.Right;
				}
				else
				{
					curTree = tree.Left;
				}

				while (curTree.Left != null)
				{
					curTree = curTree.Left;
				}

				T temp = curTree.Val;
				Remove(temp);
				tree.Val = temp;

				return true;
			}

			//Удаление листьев
			if (tree.Left == null && tree.Right == null && tree.Parent != null)
			{
				if (tree == tree.Parent.Left)
				{
					tree.Parent.Left = null;
				}
				else
				{
					tree.Parent.Right = null;
				}
				return true;
			}

			//Удаление узла, имеющего левое поддерево, но не имеющее правого поддерева
			if (tree.Left != null && tree.Right == null)
			{
				//Меняем родителя
				tree.Left.Parent = tree.Parent;

				if (tree == tree.Parent.Left)
				{
					tree.Parent.Left = tree.Left;
				}
				else if (tree == tree.Parent.Right)
				{
					tree.Parent.Right = tree.Left;
				}
				return true;
			}

			//Удаление узла, имеющего правое поддерево, но не имеющее левого поддерева
			if (tree.Left == null && tree.Right != null)
			{
				tree.Right.Parent = tree.Parent;

				if (tree == tree.Parent.Left)
				{
					tree.Parent.Left = tree.Right;
				}
				else if (tree == tree.Parent.Right)
				{
					tree.Parent.Right = tree.Right;
				}
				return true;
			}

			//Удаляем узел, имеющий поддеревья с обеих сторон
			if (tree.Right != null && tree.Left != null)
			{
				curTree = tree.Right;

				while (curTree.Left != null)
				{
					curTree = curTree.Left;
				}

				//Если самый левый элемент является первым потомком
				if (curTree.Parent == tree)
				{
					curTree.Left = tree.Left;
					tree.Left.Parent = curTree;
					curTree.Parent = tree.Parent;

					if (tree == tree.Parent.Left)
					{
						tree.Parent.Left = curTree;
					}
					else if (tree == tree.Parent.Right)
					{
						tree.Parent.Right = curTree;
					}
					return true;
				}
				//Если самый левый элемент НЕ является первым потомком
				else
				{
					if (curTree.Right != null)
					{
						curTree.Right.Parent = curTree.Parent;
					}

					curTree.Parent.Left = curTree.Right;
					curTree.Right = tree.Right;
					curTree.Left = tree.Left;

					tree.Left.Parent = curTree;
					tree.Right.Parent = curTree;

					curTree.Parent = tree.Parent;

					if (tree == tree.Parent.Left)
					{
						tree.Parent.Left = curTree;
					}
					else if (tree == tree.Parent.Right)
					{
						tree.Parent.Right = curTree;
					}

					return true;
				}
			}
			return false;
		}

		public override string ToString()
		{
			return Val.ToString();
		}
	}
}
