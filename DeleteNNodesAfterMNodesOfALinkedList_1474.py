class ListNode:
    def __init__(self, val = 0, next = None):
        self.val = val
        self. next = next

    def delete_nodes(head, m, n):
        # Use fictive dummy node for simplicity fo work
        dummy = ListNode()
        dummy.next = head

        current = dummy

        while current is not None:
            # Go forward M nodes
            for _ in range(m):
                if current.next is None:
                    return dummy.next
                current = current.next

            # Step 2. Delete N nodes
            temp = current
            for _ in range(n+1):
                if temp.next is None:
                    break
                temp = temp.next

            # Assign next link
            current.next = temp
    
        return dummy.next
