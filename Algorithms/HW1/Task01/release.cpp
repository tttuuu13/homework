#include <stdexcept>
#include "list.h"
#include "unordered_set"

List::List() {
  _size = 0;
  head = tail = nullptr;
}

List::List(const List &other) {
  head = tail = nullptr;
  _size = 0;
  if (other.head != nullptr) {
    head = tail = new Node(nullptr, nullptr, other.head->value);
    Node *curr = other.head;
    while (curr != nullptr) {
      push_back(curr->value);
      curr = curr->next;
    }
  }
}

List::List(std::vector<int> array) {
  _size = 0;
  head = tail = nullptr;
  for (int value : array) {
    push_back(value);
  }
}

List::~List() {
  clear();
}

int List::front() {
  return head->value;
}

int List::back() {
  return tail->value;
}

void List::push_back(int value) {
  if (_size == 0) {
    head = tail = new Node(nullptr, nullptr, value);
  } else {
    Node *newNode = new Node(tail, nullptr, value);
    tail->next = newNode;
    tail = newNode;
  }
  _size++;
}

void List::push_front(int value) {
  if (_size == 0) {
    head = tail = new Node(nullptr, nullptr, value);
  } else {
    Node *newNode = new Node(nullptr, head, value);
    head->prev = newNode;
    head = newNode;
  }
  _size++;
}

void List::insert(Node *pos, int value) {
  if (head != nullptr && pos != nullptr) {
    if (pos == tail) {
      push_back(value);
      return;
    }
    Node *curr = head;
    while (curr != tail) {
      if (curr == pos) {
        Node *newNode = new Node(curr, curr->next, value);
        curr->next->prev = newNode;
        curr->next = newNode;
        _size++;
        return;
      }
      curr = curr->next;
    }
  }
  throw std::runtime_error("Incorrect position!");
}

void List::pop_front() {
  if (_size == 0) {
    throw std::runtime_error("Deleting in empty list");
  } else if (_size == 1) {
    delete head;
    head = tail = nullptr;
    _size--;
  } else {
    Node *newHead = head->next;
    delete head;
    head = newHead;
    head->prev = nullptr;
    _size--;
  }
}

void List::pop_back() {
  if (_size == 0) {
    throw std::runtime_error("Deleting in empty list");
  } else if (_size == 1) {
    delete tail;
    head = tail = nullptr;
    _size--;
  } else {
    Node *newTail = tail->prev;
    delete tail;
    tail = newTail;
    tail->next = nullptr;
    _size--;
  }
}

void List::erase(Node *pos) {
  if (head != nullptr && pos != nullptr) {
    if (pos == tail) {
      pop_back();
    } else if (pos == head) {
      pop_front();
    } else {
      Node *curr = head;
      while (curr != tail) {
        if (curr == pos) {
          curr->prev->next = curr->next;
          curr->next->prev = curr->prev;
          curr->value = 0;
          curr->next = curr->prev = nullptr;
          _size--;
          return;
        }
        curr = curr->next;
      }
    }
  } else {
    throw std::runtime_error("Incorrect position!");
  }
}

void List::reverse() {
  if (head != nullptr) {
    Node *curr = head;
    while (curr != nullptr) {
      std::swap(curr->prev, curr->next);
      curr = curr->prev;
    }
  }
  std::swap(head, tail);
}

void List::remove_duplicates() {
  if (head != nullptr) {
    std::unordered_set<int> unique_nums;
    Node *curr = head;
    while (curr != tail) {
      if (unique_nums.find(curr->value) != unique_nums.end()) {
        curr->prev->next = curr->next;
        curr->next->prev = curr->prev;
        Node *node_to_delete = curr;
        curr = curr->next;
        delete node_to_delete;
        _size--;
      } else {
        unique_nums.insert(curr->value);
        curr = curr->next;
      }
    }
    if (unique_nums.find(tail->value) != unique_nums.end()) {
      pop_back();
    }
  }
}

void List::replace(int old_value, int new_value) {
  if (head != nullptr) {
    Node *curr = head;
    while (curr != nullptr) {
      if (curr->value == old_value) {
        curr->value = new_value;
      }
      curr = curr->next;
    }
  }
}

void List::merge(const List &other) {
  if (other.head != nullptr) {
    Node *curr = other.head;
    while (curr != nullptr) {
      push_back(curr->value);
      curr = curr->next;
    }
  }
}

bool List::check_cycle() const {
  if (head == nullptr) {
    return false;
  }
  Node *slow = head;
  Node *fast = head;

  while (slow != nullptr && fast->next != nullptr) {
    slow = slow->next;
    fast = fast->next->next;

    if (slow == fast) {
      return true;
    }
  }
  return false;
}

void List::clear() {
  if (head != nullptr) {
    if (check_cycle()) {
      Node *slow = head;
      Node *fast = head;

      while (slow != nullptr && fast->next != nullptr) {
        slow = slow->next;
        delete slow->prev;
        fast = fast->next->next;

        if (slow == fast) {
          return;
        }
      }
    } else {
      Node *curr = head;
      while (curr != nullptr) {
        Node *nodeToDelete = curr;
        curr = curr->next;
        delete nodeToDelete;
      }
      head = nullptr;
      tail = nullptr;
      _size = 0;
    }
  }
}

size_t List::size() const {
  return _size;
}

bool List::empty() const {
  return _size == 0;
}

void List::copy(const List &other) {
  clear();
  if (other.head != nullptr) {
    Node *curr = other.head;
    while (curr != nullptr) {
      push_back(curr->value);
      curr = curr->next;
    }
  }
}
