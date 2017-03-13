/*
  Insert Node at the end of a linked list 
  head pointer input could be NULL as well for empty list
  Node is defined as 
  class Node {
     int data;
     Node next;
  }
*/
// http://www.geeksforgeeks.org/write-a-function-to-get-the-intersection-point-of-two-linked-lists/
// the simplest loop solution
// there are more advanced techniques: http://www.geeksforgeeks.org/write-a-function-to-get-the-intersection-point-of-two-linked-lists/
int FindMergeNode(Node headA, Node headB) {
    Node currentA = headA;
    Node currentB = headB;
    int result = -1;
    
    while (currentA != null) {
        currentB = headB;
            
        while (currentB != null) {
            if (currentA == currentB) {
                result = currentB.data;    
                return result;
            }
            
            currentB = currentB.next;
        }
        
        currentA = currentA.next;
    }
    
    return result;
}
