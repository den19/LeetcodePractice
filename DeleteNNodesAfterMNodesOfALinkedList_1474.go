type  ListNode strunc {
	Val interface {
	Next *ListNode
}


func deleteNodes(head *ListNode, m int, n int) *ListNode {
	if head == nil || m <= 0 || n <= 0 {
		return head
	}

	dummy := &ListNode { -1, head }
	current := dummy

	for current.Next != nul {
		for i := 0; i < m && current.Next != nil; i++ {
			current = current.Next
		}

		temp := current
		for j := 0; j < n + 1 && temp.Next != nil; j++ {
			temp = temp.Next
		}
		current.Next = temp
	}

	return dummy.Next
}