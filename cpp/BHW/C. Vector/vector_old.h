#pragma once
#include <iostream>
#include <algorithm>

template<typename T>
class Iterator {
 public:
  using iterator_category = std::random_access_iterator_tag; // NOLINT
  using value_type = T; // NOLINT
  using difference_type = std::ptrdiff_t; // NOLINT
  using pointer = T *; // NOLINT
  using reference = T &; // NOLINT
  explicit Iterator(pointer ptr) : ptr_(ptr) {};
  Iterator &operator+(const uint64_t increment) {
    ptr_ += increment;
    return *this;
  }
  Iterator &operator++() {
    ++ptr_;
    return *this;
  }
  reference operator*() const {
    return *ptr_;
  }
  bool operator!=(const Iterator &other) {
    return ptr_ != other.ptr_;
  }
 private:
  pointer ptr_;
};
template<typename T>
class ConstIterator {
 public:
  using iterator_category = std::random_access_iterator_tag; // NOLINT
  using value_type = T; // NOLINT
  using difference_type = std::ptrdiff_t; // NOLINT
  using pointer = T *; // NOLINT
  using reference = const T &; // NOLINT
  explicit ConstIterator(pointer ptr) : ptr_(ptr) {};
  ConstIterator &operator+(const uint64_t increment) {
    ptr_ += increment;
    return *this;
  }
  ConstIterator &operator++() {
    ++ptr_;
    return *this;
  }
  reference operator*() const {
    return *ptr_;
  }
  bool operator!=(const ConstIterator &other) {
    return ptr_ != other.ptr_;
  }
 private:
  pointer ptr_;
};
template<typename T>
class ReverseIterator {
 public:
  using iterator_category = std::random_access_iterator_tag; // NOLINT
  using value_type = T; // NOLINT
  using difference_type = std::ptrdiff_t; // NOLINT
  using pointer = T *; // NOLINT
  using reference = T &; // NOLINT
  explicit ReverseIterator(pointer ptr) : ptr_(ptr) {};
  ReverseIterator &operator+(const uint64_t increment) {
    ptr_ += increment;
    return *this;
  }
  ReverseIterator &operator++() {
    --ptr_;
    return *this;
  }
  reference operator*() const {
    return *ptr_;
  }
  bool operator!=(const ReverseIterator &other) {
    return ptr_ != other.ptr_;
  }
 private:
  pointer ptr_;
};
template<typename T>
class ConstReverseIterator {
 public:
  using iterator_category = std::random_access_iterator_tag; // NOLINT
  using value_type = T; // NOLINT
  using difference_type = std::ptrdiff_t; // NOLINT
  using pointer = T *; // NOLINT
  using reference = const T &; // NOLINT
  explicit ConstReverseIterator(pointer ptr) : ptr_(ptr) {};
  ConstReverseIterator &operator+(const uint64_t increment) {
    ptr_ += increment;
    return *this;
  }
  ConstReverseIterator &operator++() {
    --ptr_;
    return *this;
  }
  reference operator*() const {
    return *ptr_;
  }
  bool operator!=(const ConstReverseIterator &other) {
    return ptr_ != other.ptr_;
  }
 private:
  pointer ptr_;
};

template<typename T>
class Vector {
 public:
  using ValueType = T;
  using Pointer = T *;
  using ConstPointer = const T *;
  using Reference = T &;
  using ConstReference = const T &;
  using SizeType = size_t;
  using Iterator = Iterator<T>;
  using ConstIterator = ConstIterator<T>;
  using ReverseIterator = ReverseIterator<T>;
  using ConstReverseIterator = ConstReverseIterator<T>;
  Pointer arr_;
  size_t capacity_;
  size_t size_;

  Vector() {
    capacity_ = 0;
    size_ = 0;
    arr_ = new T[capacity_];
  };
  explicit Vector(size_t init_size) {
    capacity_ = init_size;
    size_ = init_size;
    arr_ = new T[capacity_];
  };
  Vector(size_t init_size, ConstReference value) {
    size_ = 0;
    capacity_ = init_size;
    arr_ = new T[capacity_];
    for (int i = 0; i < init_size; i++) {
      PushBack(value);
    }
  };
  template<class Iterator, class = std::enable_if_t<std::is_base_of_v<std::forward_iterator_tag,
                                                                      typename std::iterator_traits<Iterator>::iterator_category>>>
  Vector(Iterator first, Iterator last) {
    size_ = capacity_ = last - first;
    arr_ = new T[capacity_];
    size_t i = 0;
    for (; first != last; first++) {
      arr_[i] = *first;
      i++;
    }
  }
  Vector(const std::initializer_list<T> &init_list) {
    size_ = capacity_ = init_list.size();
    arr_ = new T[capacity_];
    size_t i = 0;
    for (const auto &elem : init_list) {
      arr_[i] = elem;
      i++;
    }
  }
  Vector(const Vector<T> &other) noexcept {
    size_ = other.Size();
    capacity_ = other.Capacity();
    arr_ = other.arr_;
  }
  Vector<T> &operator=(const Vector<T> &other) noexcept {
    size_ = other.Size();
    capacity_ = other.Capacity();
    arr_ = other.arr_;
    return *this;
  }
  Vector(Vector<T> &&other) noexcept {
    size_ = other.Size();
    other.size_ = 0;
    capacity_ = other.Capacity();
    other.capacity_ = 0;
    arr_ = other.arr_;
    other.arr_ = nullptr;
  }
  Vector<T> &operator=(Vector<T> &&other) noexcept {
    size_ = other.Size();
    other.size_ = 0;
    capacity_ = other.Capacity();
    other.capacity_ = 0;
    arr_ = other.arr_;
    other.arr_ = nullptr;
    return *this;
  }
  ~Vector() = default;

  Iterator begin() const { // NOLINT
    return Iterator(arr_);
  }
  ConstIterator cbegin() const { // NOLINT
    return ConstIterator(arr_);
  }
  ReverseIterator rbegin() const { // NOLINT
    return ReverseIterator(arr_);
  }
  ConstReverseIterator crbegin() const { // NOLINT
    return ConstReverseIterator(arr_);
  }
  Iterator end() const { // NOLINT
    return Iterator(arr_ + size_);
  }
  ConstIterator cend() const { // NOLINT
    return ConstIterator(arr_ + size_);
  }
  ReverseIterator rend() const { // NOLINT
    return ReverseIterator(arr_ + size_);
  }
  ConstReverseIterator crend() const { // NOLINT
    return ConstReverseIterator(arr_ + size_);
  }

  ConstReference operator[](size_t index) const {
    return arr_[index];
  };
  Reference operator[](size_t index) {
    return arr_[index];
  };
  bool operator>(const Vector<T> &other) const {
    for (size_t i = 0; i < std::max(this->Size(), other.Size()); i++) {
      T e1 = i >= Size() ? 0 : this->arr_[i];
      T e2 = i >= other.Size() ? 0 : other.arr_[i];
      if (e1 != e2) {
        return e1 > e2;
      }
    }
    return false;
  }
  bool operator==(const Vector<T> &other) const {
    if (Size() == other.Size()) {
      for (size_t i = 0; i < Size(); i++) {
        if (arr_[i] != other.arr_[i]) {
          return false;
        }
      }
      return true;
    }
    return false;
  }
  bool operator<(const Vector<T> &other) const {
    return (!(*this > other) && !(*this == other));
  }
  bool operator>=(const Vector<T> &other) const {
    return !(*this < other);
  }
  bool operator<=(const Vector<T> &other) const {
    return !(*this > other);
  }
  bool operator!=(const Vector<T> &other) const {
    return !(*this == other);
  }

  ConstReference At(size_t index) const {
    if (index <= size_) {
      throw std::out_of_range("IndexOutOfRange");
    }
    return arr_[index];
  };
  Reference At(size_t index) {
    if (index <= size_) {
      throw std::out_of_range("IndexOutOfRange");
    }
    return arr_[index];
  };

  size_t Size() const {
    return size_;
  }
  size_t Capacity() const {
    return capacity_;
  }
  bool Empty() const {
    return size_ == 0;
  }

  ConstReference Front() const {
    return arr_[0];
  };
  Reference Front() {
    return arr_[0];
  };

  ConstReference Back() const {
    return arr_[size_ - 1];
  };
  Reference Back() {
    return arr_[size_ - 1];
  };

  Pointer Data() const {
    return arr_;
  };

  Vector<T> &Swap(Vector<T> &other) {
    std::swap(*this, other);
    return *this;
  };

  Vector<T> &PushBack(const T &element) {
    if (size_ >= capacity_) {
      Reserve(2 * capacity_);
    }
    size_++;
    this->Back() = element;
    return *this;
  };

  Vector<T> PushBack(const T &&element) {
    T lvalue = element;
    return PushBack(lvalue);
  }

  Vector<T> &Resize(size_t new_size, ConstReference value) {
    if (new_size == Size()) {
      return *this;
    }
    auto new_vec = new Vector<T>(new_size, value);
    Iterator new_it = new_vec->begin();
    for (ConstIterator it = cbegin(); it != cend(); ++it) {
      *new_it = *it;
      ++new_it;
    }
    *this = *new_vec;
    return *this;
  };

  Vector<T> &Resize(size_t new_size) {
    Resize(new_size, T{});
    return *this;
  };

  Vector<T> &Reserve(size_t new_cap) {
    capacity_ = std::max(capacity_, new_cap);
    return *this;
  };

  Vector<T> &ShrinkToFit() {
    auto shrinked = new T[size_];
    for (size_t i = 0; i < size_; i++) {
      shrinked[i] = arr_[i];
    }
    delete[] arr_;
    capacity_ = size_;
    arr_ = shrinked;
    return *this;
  }

  Vector<T> &Clear() {
    size_ = 0;
    return *this;
  }

  Vector<T> &PopBack() {
    size_ = std::max(0, (static_cast<int>(size_) - 1));
    return *this;
  }

  void Print() const {
    std::cout << "Vector only: ";
    for (size_t i = 0; i < size_; i++) {
      std::cout << arr_[i] << " ";
    }
    std::cout << "\nWhole buffer: ";
    for (size_t i = 0; i < capacity_; i++) {
      std::cout << arr_[i] << " ";
    }
  }; // TODO DELETE
};