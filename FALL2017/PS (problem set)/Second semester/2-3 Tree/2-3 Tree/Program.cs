using System;
using System.Collections.Generic;

namespace assignment2bro
{
    class Operation
    {
        public string operation;
        public int number;

        public Operation(string operation, int number)
        {
            this.operation = operation;
            this.number = number;
        }
    }

    class TreeManager
    {
        TreeStack currentStack;
        int counter = 0;
        string line;
        bool flag = true;
        String path;

        public TreeManager(String path)
        {
            this.path = path;
        }

        public void Run()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            string firstChar;
            string[] splitLine = new string[2];
            TwoThreeTree tree = new TwoThreeTree();

            while ((line = file.ReadLine()) != null)
            {
                splitLine = line.Split(' ');
                firstChar = splitLine[0];

                switch (firstChar)
                {
                    case "#":

                        if (flag)
                        {
                            currentStack = new TreeStack(int.Parse(splitLine[1]));
                            flag = false;

                        }
                        else
                        {
                            currentStack = new TreeStack(int.Parse(splitLine[1]));

                            foreach (var o in currentStack.operations)
                            {
                                if (o.operation == "I")
                                {
                                    tree.Insert(o.number);

                                }
                                else if (o.operation == "D")
                                {
                                    tree.Delete(o.number);
                                }

                            }

                            tree.root.PrintNode(1);
                            Console.WriteLine("Line Numbers " + counter);
                        }

                        break;

                    case "I":
                        currentStack.Push(new Operation("I", int.Parse(splitLine[1])));
                        break;

                    case "D":
                        currentStack.Push(new Operation("D", int.Parse(splitLine[1])));
                        break;
                }

                counter++;
            }

            foreach (var o in currentStack.operations)
            {
                if (o.operation == "I")
                {
                    tree.Insert(o.number);
                }
                else if (o.operation == "D")
                {
                    tree.Delete(o.number);
                }
            }

            tree.root.PrintNode(1);
            Console.WriteLine("Line Numbers " + counter);

            file.Close();
            Console.ReadLine();
        }

        void ApplyOperations(Tree tree)
        {

        }
    }

    class TreeStack
    {
        public List<Operation> operations;
        int pTop;
        int size;

        public TreeStack(int size)
        {
            operations = new List<Operation>();
            this.size = size;
            pTop = -1;
        }

        public void Push(Operation operation)
        {
            operations.Add(operation);
            pTop++;
        }

        public Operation Pop()
        {
            pTop--;
            return operations[pTop + 1];
        }

        public bool IsEmpty()
        {
            bool b = pTop == -1 ? true : false;
            return b;
        }

    }

    public abstract class TreeNode
    {
        public bool isLeaf;
        public int[] elements;
        public TreeNode[] children;
        public TreeNode parent;
        public int numberOfElements;

        public TreeNode()
        {
            this.parent = null;
        }

        public bool IsLeaf()
        {
            bool result = true;
            for (int i = 0; i < children.Length; i++)
            {
                if (children[i] != null)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public int NumberOfElements()
        {
            int count = 0;
            for (int i = 0; i < this.elements.Length; i++)
            {
                if (elements[i] != 0)
                    count++;
            }
            return count;
        }

        public void PrintNode(int indent)
        {
            int i = 0;
            for (i = 0; i < indent; i++)
                Console.Write(" ");
            Console.Write("<-");
            for (i = 0; i < this.elements.Length; i++)
            {
                if (true)
                    Console.Write(this.elements[i] + "-");

            }

            Console.Write(">");
            Console.WriteLine();

            for (i = 0; i < this.children.Length; i++)
            {
                if (children[i] != null)
                    children[i].PrintNode(indent + 14);
            }

        }
    }

    public class TwoThreeTreeNode : TreeNode
    {
        public TwoThreeTreeNode()
        {
            elements = new int[2];
            children = new TwoThreeTreeNode[4];
        }
    }

    public abstract class Tree
    {
        public TreeNode root;
        public int limit;

        public Tree()
        {
            limit = 0;
        }

        public void initRoot()
        {
            root.isLeaf = true;
            root.parent = null;
        }

        public void Insert(int element)
        {
            TreeNode treeNode = FindSubtreeLeaf(root, element);
            if (!TryInsert(treeNode, element))
                Split(treeNode, element);
        }

        public bool TryInsert(TreeNode treeNode, int element)
        {
            bool result = true;

            if (treeNode.NumberOfElements() == 0 && treeNode.parent == null)
            {
                treeNode.elements[0] = element;

            }

            else if (treeNode.NumberOfElements() < this.limit)
            {
                treeNode.elements[treeNode.NumberOfElements()] = element;

                this.SortElements(treeNode.elements, treeNode.NumberOfElements());

            }
            else
            {
                result = false;
            }

            return result;
        }

        public virtual void Split(TreeNode treeNode, int element)
        {
            Console.WriteLine("This method should be overrided");
        }

        public TreeNode DeleteElement(int element)
        {
            int inOrderInd;
            TreeNode leafNode;
            TreeNode inOrderSuccessor;
            int tempElement;
            TreeNode shouldFixed = null;
            TreeNode node = FindNode(root, element);

            if (node != null)
            {
                int ind = node.elements[0] == element ? 0 : node.elements[1] == element ? 1 : 2;

                if (node.IsLeaf() == false)
                {
                    inOrderSuccessor = InOrderSuccessor(element, node);
                    inOrderInd = 0;
                    tempElement = node.elements[ind];
                    node.elements[ind] = inOrderSuccessor.elements[inOrderInd];
                    inOrderSuccessor.elements[inOrderInd] = tempElement;

                    leafNode = inOrderSuccessor;
                }
                else
                {
                    leafNode = node;
                }

                if (element == leafNode.elements[0])
                {
                    if (leafNode.NumberOfElements() == 1)
                    {
                        leafNode.elements[0] = 0;
                    }
                    else if (leafNode.NumberOfElements() == 2)
                    {
                        leafNode.elements[0] = leafNode.elements[1];
                        leafNode.elements[1] = 0;
                    }
                    else
                    {
                        leafNode.elements[0] = leafNode.elements[1];
                        leafNode.elements[1] = leafNode.elements[2];
                        leafNode.elements[2] = 0;
                    }
                }
                else if (element == leafNode.elements[1])
                {
                    if (leafNode.NumberOfElements() == 2)
                    {
                        leafNode.elements[1] = 0;
                    }
                    else
                    {
                        leafNode.elements[1] = leafNode.elements[2];
                        leafNode.elements[2] = 0;
                    }
                }

                else if (element == leafNode.elements[2])
                {
                    leafNode.elements[2] = 0;
                }
                else
                {
                    Console.WriteLine("There must be a mistake, element couldn't be found in the node!");
                }

                if (leafNode.NumberOfElements() == 0)
                {
                    shouldFixed = leafNode;
                }
            }
            else
            {
                Console.WriteLine(element + " Couldn't found in the tree, thus process terminated");
            }

            return shouldFixed;
        }


        public TreeNode FindSubtreeLeaf(TreeNode node, int element)
        {
            if (node.IsLeaf())
                return node;

            else
            {
                if (element < node.elements[0])
                    return this.FindSubtreeLeaf(node.children[0], element);

                else if (node.NumberOfElements() == 1 || (element > node.elements[0] && element < node.elements[1]))
                    return this.FindSubtreeLeaf(node.children[1], element);

                else if (node.NumberOfElements() == 2 || (element > node.elements[1] && element < node.elements[2]))
                    return this.FindSubtreeLeaf(node.children[2], element);

                else
                    return this.FindSubtreeLeaf(node.children[3], element);
            }
        }

        public TreeNode FindNode(TreeNode node, int element)
        {
            bool isFound = false;
            if (node != null)
            {
                for (int i = 0; i < node.NumberOfElements(); i++)
                {
                    if (node.elements[i] == element)
                        isFound = true;
                }

                if (isFound == true)
                    return node;

                else if (node.NumberOfElements() == 1)
                {
                    if (element < node.elements[0])
                        return FindNode(node.children[0], element);
                    else
                        return FindNode(node.children[1], element);
                }
                else if (node.NumberOfElements() == 2)
                {
                    if (element < node.elements[0])
                    {
                        return FindNode(node.children[0], element);
                    }
                    else if (element > node.elements[1])
                    {
                        return FindNode(node.children[2], element);
                    }
                    else
                    {
                        return FindNode(node.children[1], element);
                    }
                }
                else if (node.NumberOfElements() == 3)
                {
                    if (element < node.elements[0])
                    {
                        return FindNode(node.children[0], element);
                    }
                    else if (element > node.elements[0] && element < node.elements[1])
                    {
                        return FindNode(node.children[1], element);
                    }
                    else if (element > node.elements[1] && element < node.elements[2])
                    {
                        return FindNode(node.children[2], element);
                    }
                    else
                    {
                        return FindNode(node.children[3], element);
                    }
                }
            }

            return null;
        }

        public TreeNode InOrderSuccessor(int element, TreeNode node)
        {
            TreeNode next;

            if (node.children[0] != null && node.children[1] != null && node.children[2] != null && node.children[3] != null)
            {
                if (node.elements[0] == element)
                {
                    next = node.children[1];
                }
                else if (node.elements[1] == element)
                {
                    next = node.children[2];
                }
                else
                {
                    next = node.children[3];
                }
            }

            else if (node.children[0] != null && node.children[1] != null && node.children[2] != null)
            {
                if (node.elements[0] == element)
                {
                    next = node.children[1];
                }
                else
                {
                    next = node.children[2];
                }
            }
            else
            {
                next = node.children[1];
            }

            while (next.IsLeaf() == false)
            {
                next = next.children[0];
            }
            return next;
        }

        public int HasChildWithTwoElement(TreeNode node)
        {
            int result = -1;

            if (node.NumberOfElements() == 1)
            {
                for (int i = 0; i < node.children.Length; i++)
                {
                    if (node.children[i] != null)
                    {
                        if (node.children[i].NumberOfElements() == 2 || node.children[i].NumberOfElements() == 3)
                        {
                            result = i;
                            result = result + node.children[i].NumberOfElements() * 10;
                            break;
                        }
                    }
                }
            }

            else if (node.NumberOfElements() == 2)
            {
                if (node.children[0].NumberOfElements() == 0)
                {
                    for (int i = 0; i < node.children.Length; i++)
                    {
                        if (node.children[i] != null)
                        {
                            if (node.children[i].NumberOfElements() == 2 || node.children[i].NumberOfElements() == 3)
                            {
                                result = i;
                                result = result + node.children[i].NumberOfElements() * 10;
                                break;
                            }
                        }
                    }
                }

                else
                {
                    for (int i = node.children.Length - 1; i >= 0; i--)
                    {
                        if (node.children[i] != null)
                        {
                            if (node.children[i].NumberOfElements() == 2 || node.children[i].NumberOfElements() == 3)
                            {
                                result = i;
                                result = result + node.children[i].NumberOfElements() * 10;
                                break;
                            }
                        }
                    }
                }
            }

            else if (node.NumberOfElements() == 3)
            {
                if (node.children[0].NumberOfElements() == 0)
                {
                    for (int i = 0; i < node.children.Length; i++)
                    {
                        if (node.children[i] != null)
                        {
                            if (node.children[i].NumberOfElements() == 2 || node.children[i].NumberOfElements() == 3)
                            {
                                result = i;
                                result = result + node.children[i].NumberOfElements() * 10;
                                break;
                            }
                        }
                    }
                }

                else
                {
                    if (node.children[1].NumberOfElements() == 0)
                    {
                        for (int i = 1; i < node.children.Length; i++)
                        {
                            if (node.children[i] != null)
                            {
                                if (node.children[i].NumberOfElements() == 2 || node.children[i].NumberOfElements() == 3)
                                {
                                    result = i;
                                    result = result + node.children[i].NumberOfElements() * 10;
                                    break;
                                }
                            }
                        }

                        if (result == -1)
                        {
                            if (node.children[0].NumberOfElements() == 2 || node.children[0].NumberOfElements() == 3)
                            {
                                result = node.children[0].NumberOfElements() * 10;
                            }
                        }
                    }

                    else
                    {
                        for (int i = node.children.Length - 1; i >= 0; i--)
                        {
                            if (node.children[i] != null)
                            {
                                if (node.children[i].NumberOfElements() == 2 || node.children[i].NumberOfElements() == 3)
                                {
                                    result = i;
                                    result = result + node.children[i].NumberOfElements() * 10;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public void Merge(TreeNode node)
        {
            if (node.parent.NumberOfElements() == 1)
            {
                if (node.parent.children[0] == node)
                {
                    node.parent.children[1].elements[1] = node.parent.children[1].elements[0];
                    node.parent.children[1].elements[0] = node.parent.elements[0];
                    node.parent.elements[0] = 0;

                    node.parent.children[0] = node.parent.children[1];
                    node.parent.children[1] = null;

                    if (node.IsLeaf() == false)
                    {
                        node.parent.children[0].children[2] = node.parent.children[0].children[1];
                        node.parent.children[0].children[1] = node.parent.children[0].children[0];
                        node.parent.children[0].children[0] = node.children[0];

                        node.parent.children[0].children[0].parent = node.parent.children[0];
                    }
                }

                else
                {
                    node.parent.children[0].elements[1] = node.parent.elements[0];
                    node.parent.elements[0] = 0;

                    node.parent.children[1] = null;

                    if (node.IsLeaf() == false)
                    {
                        node.parent.children[0].children[2] = node.children[0];
                        node.parent.children[0].children[2].parent = node.parent.children[0];
                    }
                }
            }

            else if (node.parent.NumberOfElements() == 2)
            {
                if (node.parent.children[0] == node)
                {
                    node.parent.children[1].elements[1] = node.parent.children[1].elements[0];
                    node.parent.children[1].elements[0] = node.parent.elements[0];
                    node.parent.elements[0] = node.parent.elements[1];
                    node.parent.elements[1] = 0;

                    node.parent.children[0] = node.parent.children[1];
                    node.parent.children[1] = node.parent.children[2];
                    node.parent.children[2] = null;

                    if (node.IsLeaf() == false)
                    {
                        node.parent.children[0].children[2] = node.parent.children[0].children[1];
                        node.parent.children[0].children[1] = node.parent.children[0].children[0];
                        node.parent.children[0].children[0] = node.children[0];

                        node.parent.children[0].children[0].parent = node.parent.children[0];
                    }

                }

                else if (node.parent.children[1] == node)
                {
                    node.parent.children[0].elements[1] = node.parent.elements[0];
                    node.parent.elements[0] = node.parent.elements[1];
                    node.parent.elements[1] = 0;

                    node.parent.children[1] = node.parent.children[2];
                    node.parent.children[2] = null;

                    if (node.IsLeaf() == false)
                    {
                        node.parent.children[0].children[2] = node.children[0];
                        node.parent.children[0].children[2].parent = node.parent.children[0];
                    }
                }

                else
                {
                    node.parent.children[1].elements[1] = node.parent.elements[1];
                    node.parent.elements[1] = 0;

                    node.parent.children[2] = null;

                    if (node.IsLeaf() == false)
                    {
                        node.parent.children[1].children[2] = node.children[0];
                        node.parent.children[1].children[2].parent = node.parent.children[1];
                    }
                }
            }
            else if (node.parent.NumberOfElements() == 3)
            {
                if (node.parent.children[0] == node)
                {
                    node.parent.children[1].elements[1] = node.parent.children[1].elements[0];
                    node.parent.children[1].elements[0] = node.parent.elements[0];
                    node.parent.elements[0] = node.parent.elements[1];
                    node.parent.elements[1] = node.parent.elements[2];
                    node.parent.elements[2] = 0;

                    node.parent.children[0] = node.parent.children[1];
                    node.parent.children[1] = node.parent.children[2];
                    node.parent.children[2] = node.parent.children[3];
                    node.parent.children[3] = null;

                    if (node.IsLeaf() == false)
                    {
                        node.parent.children[0].children[2] = node.parent.children[0].children[1];
                        node.parent.children[0].children[1] = node.parent.children[0].children[0];
                        node.parent.children[0].children[0] = node.children[0];

                        node.parent.children[0].children[0].parent = node.parent.children[0];
                    }
                }
                else if (node.parent.children[1] == node)
                {
                    node.parent.children[0].elements[1] = node.parent.elements[0];
                    node.parent.elements[0] = node.parent.elements[1];
                    node.parent.elements[1] = node.parent.elements[2];
                    node.parent.elements[2] = 0;

                    node.parent.children[1] = node.parent.children[2];
                    node.parent.children[2] = node.parent.children[3];
                    node.parent.children[3] = null;

                    if (node.IsLeaf() == false)
                    {
                        node.parent.children[0].children[2] = node.children[0];
                        node.parent.children[0].children[2].parent = node.parent.children[0];
                    }
                }
                else if (node.parent.children[2] == node)
                {
                    node.parent.children[1].elements[1] = node.parent.elements[1];
                    node.parent.elements[1] = node.parent.elements[2];
                    node.parent.elements[2] = 0;
                    node.parent.children[2] = node.parent.children[3];
                    node.parent.children[3] = null;

                    if (node.IsLeaf() == false)
                    {
                        node.parent.children[1].children[2] = node.children[0];
                        node.parent.children[1].children[2].parent = node.parent.children[1];
                    }
                }
                else if (node.parent.children[3] == node)
                {
                    node.parent.children[2].elements[1] = node.parent.elements[2];
                    node.parent.elements[2] = 0;
                    node.parent.children[3] = null;

                    if (node.IsLeaf() == false)
                    {
                        node.parent.children[2].children[2] = node.children[0];
                        node.parent.children[2].children[2].parent = node.parent.children[2];
                    }
                }
            }
        }

        public void SortElements(int[] elements, int numberOfElement)
        {
            int temp = 0;

            for (int write = 0; write < numberOfElement; write++)
            {
                for (int sort = 0; sort < numberOfElement - 1; sort++)
                {
                    if (elements[sort] > elements[sort + 1])
                    {
                        temp = elements[sort + 1];
                        elements[sort + 1] = elements[sort];
                        elements[sort] = temp;
                    }
                }
            }
        }

        public void TakeElementFromNextRightSibling(TreeNode p, TreeNode node, int n)
        {
            node.elements[0] = p.elements[n];
            p.elements[n] = p.children[n + 1].elements[0];

            if (this.limit == 2)
            {
                p.children[n + 1].elements[0] = p.children[n + 1].elements[1];
                p.children[n + 1].elements[1] = 0;
            }
            else
            {

                p.children[n + 1].elements[0] = p.children[n + 1].elements[1];
                p.children[n + 1].elements[1] = p.children[n + 1].elements[2];
                p.children[n + 1].elements[2] = 0;
            }

            if (node.IsLeaf() == false)
            {
                node.children[1] = p.children[n + 1].children[0];

                if (this.limit == 2)
                {
                    p.children[n + 1].children[0] = p.children[n + 1].children[1];
                    p.children[n + 1].children[1] = p.children[n + 1].children[2];
                    p.children[n + 1].children[2] = null;
                }

                else
                {

                    p.children[n + 1].children[0] = p.children[n + 1].children[1];
                    p.children[n + 1].children[1] = p.children[n + 1].children[2];
                    p.children[n + 1].children[2] = p.children[n + 1].children[3];
                    p.children[n + 1].children[3] = null;
                }

                node.children[1].parent = node;
            }
        }

        public void TakeElementFromNextLeftSibling(TreeNode p, TreeNode node, int n)
        {
            node.elements[0] = p.elements[n];

            if (p.children[n].NumberOfElements() == 2)
            {
                p.elements[n] = p.children[n].elements[1];
                p.children[n].elements[1] = 0;
            }
            else
            {

                p.elements[n] = p.children[n].elements[2];
                p.children[n].elements[2] = 0;
            }

            if (node.IsLeaf() == false)
            {
                node.children[1] = node.children[0];

                if (p.children[n].NumberOfElements() == 1)
                {
                    node.children[0] = p.children[n].children[2];
                    p.children[n].children[2] = null;
                }
                else
                {

                    node.children[0] = p.children[n].children[3];
                    p.children[n].children[3] = null;
                }

                node.children[0].parent = node;
            }
        }

        public void TakeElementFromTwoNextRightSibling(TreeNode p, TreeNode node, int n)
        {
            node.elements[0] = p.elements[n];
            p.elements[n] = p.children[n + 1].elements[0];
            p.children[n + 1].elements[0] = p.elements[n + 1];
            p.elements[n + 1] = p.children[n + 2].elements[0];

            if (p.children[n + 2].NumberOfElements() == 2)
            {
                p.children[n + 2].elements[0] = p.children[n + 2].elements[1];
                p.children[n + 2].elements[1] = 0;
            }

            else if (p.children[n + 2].NumberOfElements() == 3)
            {
                p.children[n + 2].elements[0] = p.children[n + 2].elements[1];
                p.children[n + 2].elements[1] = p.children[n + 2].elements[2];
                p.children[n + 2].elements[2] = 0;
            }

            if (node.IsLeaf() == false)
            {
                node.children[1] = p.children[n + 1].children[0];
                p.children[n + 1].children[0] = p.children[n + 1].children[1];
                p.children[n + 1].children[1] = p.children[n + 2].children[0];

                if (p.children[n + 2].NumberOfElements() == 1)
                {
                    p.children[n + 2].children[0] = p.children[n + 2].children[1];
                    p.children[n + 2].children[1] = p.children[n + 2].children[2];
                    p.children[n + 2].children[2] = null;
                }
                else if (p.children[n + 2].NumberOfElements() == 2)
                {
                    p.children[n + 2].children[0] = p.children[n + 2].children[1];
                    p.children[n + 2].children[1] = p.children[n + 2].children[2];
                    p.children[n + 2].children[2] = p.children[n + 2].children[3];
                    p.children[n + 2].children[3] = null;
                }

                node.children[1].parent = node;
                p.children[n + 1].children[1].parent = p.children[n + 1];
            }
        }

        public void TakeElementFromTwoNextLeftSibling(TreeNode p, TreeNode node, int n)
        {
            node.elements[0] = p.elements[n - 1];
            p.elements[n - 1] = p.children[n - 1].elements[0];
            p.children[n - 1].elements[0] = p.elements[n - 2];

            if (p.children[n - 2].NumberOfElements() == 2)
            {
                p.elements[n - 2] = p.children[n - 2].elements[1];
                p.children[n - 2].elements[1] = 0;
            }

            else if (p.children[n - 2].NumberOfElements() == 3)
            {
                p.elements[n - 2] = p.children[n - 2].elements[2];
                p.children[n - 2].elements[2] = 0;
            }

            if (node.IsLeaf() == false)
            {
                node.children[1] = node.children[0];
                node.children[0] = p.children[n - 1].children[1];
                p.children[n - 1].children[1] = p.children[n - 1].children[0];

                if (p.children[n - 2].NumberOfElements() == 1)
                {
                    p.children[n - 1].children[0] = p.children[n - 2].children[2];
                    p.children[n - 2].children[2] = null;
                }

                else if (p.children[n - 2].NumberOfElements() == 2)
                {

                    p.children[n - 1].children[0] = p.children[n - 2].children[3];
                    p.children[n - 2].children[3] = null;
                }

                node.children[0].parent = node;
                p.children[n - 1].children[0].parent = p.children[n - 1];
            }
        }
    }

    public class TwoThreeTree : Tree
    {
        public TwoThreeTree()
        {
            root = new TwoThreeTreeNode();
            limit = 2;
            initRoot();
        }

        public override void Split(TreeNode twoThreeNode, int element)
        {

            TwoThreeTreeNode p;

            if (twoThreeNode.parent == null)
            {
                p = new TwoThreeTreeNode();

            }
            else
            {
                p = (TwoThreeTreeNode)twoThreeNode.parent;
            }

            TwoThreeTreeNode n1 = new TwoThreeTreeNode();
            TwoThreeTreeNode n2 = new TwoThreeTreeNode();

            int small, middle, large;

            if (element < twoThreeNode.elements[0])
            {
                small = element;
                middle = twoThreeNode.elements[0];
                large = twoThreeNode.elements[1];
            }
            else if (element > twoThreeNode.elements[1])
            {
                small = twoThreeNode.elements[0];
                middle = twoThreeNode.elements[1];
                large = element;
            }
            else
            {
                small = twoThreeNode.elements[0];
                middle = element;
                large = twoThreeNode.elements[1];
            }

            n1.elements[0] = small;
            n2.elements[0] = large;

            n1.parent = p;
            n2.parent = p;

            if (p.NumberOfElements() == 0)
            {
                p.children[0] = n1;
                p.children[1] = n2;
                root = p;
                n1.isLeaf = true;
                n2.isLeaf = true;
            }
            else if (p.NumberOfElements() == 1)
            {
                if (n2.elements[0] < p.elements[0])
                {
                    p.children[2] = p.children[1];
                    p.children[0] = n1;
                    p.children[1] = n2;
                }

                else
                {
                    p.children[1] = n1;
                    p.children[2] = n2;
                }
                n1.isLeaf = true;
                n2.isLeaf = true;
            }
            else
            {
                if (n2.elements[0] < p.elements[0] && n2.elements[0] < p.elements[1])
                {
                    p.children[3] = p.children[2];
                    p.children[2] = p.children[1];
                    p.children[0] = n1;
                    p.children[1] = n2;
                }
                else 
                if (n1.elements[0] > p.elements[0] && n1.elements[0] > p.elements[1])
                {
                    p.children[2] = n1;
                    p.children[3] = n2;
                }

                else
                {
                    p.children[3] = p.children[2];
                    p.children[1] = n1;
                    p.children[2] = n2;
                }
            }

            if (twoThreeNode.IsLeaf() == false)
            {
                twoThreeNode.children[0].parent = n1;
                twoThreeNode.children[1].parent = n1;
                twoThreeNode.children[2].parent = n2;
                twoThreeNode.children[3].parent = n2;
                n1.children[0] = twoThreeNode.children[0];
                n1.children[1] = twoThreeNode.children[1];
                n2.children[0] = twoThreeNode.children[2];
                n2.children[1] = twoThreeNode.children[3];
                n1.isLeaf = false;
                n2.isLeaf = false;
            }

            if (p.NumberOfElements() == 2)
            {
                Split(p, middle);
                if (n1.children[0] != null || n2.children[0] != null)
                {
                    if (n1.children[0].IsLeaf() || n2.children[0].IsLeaf())
                    {
                        n1.isLeaf = false;
                        n2.isLeaf = false;
                    }
                }

                else
                {
                    n1.isLeaf = true;
                    n2.isLeaf = true;
                }
                n1.parent.isLeaf = false;
                n2.parent.isLeaf = false;
            }

            else if (p.NumberOfElements() == 1)
            {
                if (p.elements[0] < middle)
                {
                    p.elements[1] = middle;
                }

                else
                {
                    p.elements[1] = p.elements[0];
                    p.elements[0] = middle;
                }
            }

            else
            {
                p.elements[0] = middle;

            }
        }

        public void Delete(int element)
        {
            TwoThreeTreeNode shouldFixed = (TwoThreeTreeNode)this.DeleteElement(element);
            if (shouldFixed != null)
                Fix(shouldFixed);
        }


        void Redistrubute(TwoThreeTreeNode node, TwoThreeTreeNode p, int situation)
        {

            //there is two different situation if the parent has two nodes
            if (p.NumberOfElements() == 1)
            {
                if (situation == 20)
                {
                    this.TakeElementFromNextLeftSibling(p, node, 0);
                }
                else
                {
                    this.TakeElementFromNextRightSibling(p, node, 0);
                }
            }

            //there is six different situation if the parent has three nodes
            else if (p.NumberOfElements() == 2)
            {
                //Check for which children is empty
                if (p.children[0].NumberOfElements() == 0)
                {
                    //situation can be 1 or 2
                    if (situation == 21)
                    {
                        this.TakeElementFromNextRightSibling(p, node, 0);
                    }
                    else
                    {
                        this.TakeElementFromTwoNextRightSibling(p, node, 0);
                    }
                }
                else if (p.children[1].NumberOfElements() == 0)
                {
                    //situation can be 0 or 2
                    if (situation == 20)
                    {
                        this.TakeElementFromNextLeftSibling(p, node, 0);
                    }
                    else
                    {
                        this.TakeElementFromNextRightSibling(p, node, 1);
                    }
                }
                else if (p.children[2].NumberOfElements() == 0)
                {
                    //situation can be 0 or 1
                    if (situation == 20)
                    {
                        this.TakeElementFromTwoNextLeftSibling(p, node, 2);
                    }
                    else
                    {
                        this.TakeElementFromNextLeftSibling(p, node, 1);
                    }
                }
            }
        }

        public void Fix(TwoThreeTreeNode node)
        {
            TwoThreeTreeNode p;

            if (node.parent == null)
            {
                if (node.children[0] == null) { return; }
                root = node.children[0];
                root.parent = null;
            }

            else
            {
                p = (TwoThreeTreeNode)node.parent;

                int situation = HasChildWithTwoElement(p);

                if (situation > -1)
                {
                    Redistrubute(node, p, situation);
                }

                else
                {
                    Merge(node);
                }

                if (node.parent.NumberOfElements() == 0)
                {
                    Fix((TwoThreeTreeNode)node.parent);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TreeManager treeManager = new TreeManager("c:\\data.txt");
            treeManager.Run();
        }
    }
}
