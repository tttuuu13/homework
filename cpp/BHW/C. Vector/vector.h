#include <algorithm>
#include <iterator>
#include <initializer_list>
#include <stdexcept>
#include <utility>
#include <type_traits>

template <typename T>
class Vector {
 public:
  using ValueType = T;
  using Pointer = T*;
  using ConstPointer = const T*;
  using Reference = T&;
  using ConstReference = const T&;
  using SizeType = std::size_t;

  using Iterator = T*;
  using ConstIterator = const T*;

  Vector() : size_(0), capacity_(0), data_(nullptr) {}

  explicit Vector(SizeType size) : size_(size), capacity_(size), data_(static_cast<T*>(operator new(size * sizeof(T)))) {
    std::uninitialized_fill(data_, data_ + size_, T());
  }

  Vector(SizeType size, const T& value) : size_(size), capacity_(size), data_(static_cast<T*>(operator new(size * sizeof(T)))) {
    std::uninitialized_fill(data_, data_ + size_, value);
  }

  template <class Iterator, class = std::enable_if_t<std::is_base_of_v<std::forward_iterator_tag, typename std::iterator_traits<Iterator>::iterator_category>>>
  Vector(Iterator first, Iterator last) {
    size_ = capacity_ = std::distance(first, last);
    data_ = static_cast<T*>(operator new(size_ * sizeof(T)));
    std::uninitialized_copy(first, last, data_);
  }

  Vector(std::initializer_list<T> init) : Vector(init.begin(), init.end()) {}

  Vector(const Vector& other) : size_(other.size_), capacity_(other.capacity_), data_(static_cast<T*>(operator new(other.capacity_ * sizeof(T)))) {
    std::uninitialized_copy(other.data_, other.data_ + other.size_, data_);
  }

  Vector(Vector&& other) noexcept : size_(other.size_), capacity_(other.capacity_), data_(other.data_) {
    other.size_ = 0;
    other.capacity_ = 0;
    other.data_ = nullptr;
  }

  Vector& operator=(const Vector& other) {
    if (this != &other) {
      Vector tmp(other);
      Swap(tmp);
    }
    return *this;
  }

  Vector& operator=(Vector&& other) noexcept {
    if (this != &other) {
      Clear();
      operator delete(data_);
      size_ = other.size_;
      capacity_ = other.capacity_;
      data_ = other.data_;
      other.size_ = 0;
      other.capacity_ = 0;
      other.data_ = nullptr;
    }
    return *this;
  }

  ~Vector() {
    Clear();
    operator delete(data_);
  }

  SizeType Size() const noexcept {
    return size_;
  }

  SizeType Capacity() const noexcept {
    return capacity_;
  }

  bool Empty() const noexcept {
    return size_ == 0;
  }

  Reference operator[](SizeType index) noexcept {
    return data_[index];
  }

  ConstReference operator[](SizeType index) const noexcept {
    return data_[index];
  }

  Reference At(SizeType index) {
    if (index >= size_) {
      throw std::out_of_range("Index out of range");
    }
    return data_[index];
  }

  ConstReference At(SizeType index) const {
    if (index >= size_) {
      throw std::out_of_range("Index out of range");
    }
    return data_[index];
  }

  Reference Front() noexcept {
    return data_[0];
  }

  ConstReference Front() const noexcept {
    return data_[0];
  }

  Reference Back() noexcept {
    return data_[size_ - 1];
  }

  ConstReference Back() const noexcept {
    return data_[size_ - 1];
  }

  Pointer Data() noexcept {
    return data_;
  }

  ConstPointer Data() const noexcept {
    return data_;
  }

  void Swap(Vector& other) noexcept {
    std::swap(size_, other.size_);
    std::swap(capacity_, other.capacity_);
    std::swap(data_, other.data_);
  }

  void Resize(SizeType new_size) {
    if (new_size > capacity_) {
      Reserve(new_size);
    }
    if (new_size > size_) {
      std::uninitialized_fill(data_ + size_, data_ + new_size, T());
    } else {
      for (SizeType i = new_size; i < size_; ++i) {
        data_[i].~T();
      }
    }
    size_ = new_size;
  }

  void Resize(SizeType new_size, const T& value) {
    if (new_size > capacity_) {
      Reserve(new_size);
    }
    if (new_size > size_) {
      std::uninitialized_fill(data_ + size_, data_ + new_size, value);
    } else {
      for (SizeType i = new_size; i < size_; ++i) {
        data_[i].~T();
      }
    }
    size_ = new_size;
  }

  void Reserve(SizeType new_cap) {
    if (new_cap > capacity_) {
      T* new_data = static_cast<T*>(operator new(new_cap * sizeof(T)));
      std::uninitialized_move(data_, data_ + size_, new_data);
      for (SizeType i = 0; i < size_; ++i) {
        data_[i].~T();
      }
      operator delete(data_);
      data_ = new_data;
      capacity_ = new_cap;
    }
  }

  void ShrinkToFit() {
    if (capacity_ > size_) {
      T* new_data = static_cast<T*>(operator new(size_ * sizeof(T)));
      std::uninitialized_move(data_, data_ + size_, new_data);
      for (SizeType i = 0; i < size_; ++i) {
        data_[i].~T();
      }
      operator delete(data_);
      data_ = new_data;
      capacity_ = size_;
    }
  }

  void Clear() noexcept {
    for (SizeType i = 0; i < size_; ++i) {
      data_[i].~T();
    }
    size_ = 0;
  }

  void PushBack(const T& value) {
    if (size_ == capacity_) {
      Reserve(capacity_ == 0 ? 1 : capacity_ * 2);
    }
    new (data_ + size_) T(value);
    ++size_;
  }

  void PushBack(T&& value) {
    if (size_ == capacity_) {
      Reserve(capacity_ == 0 ? 1 : capacity_ * 2);
    }
    new (data_ + size_) T(std::move(value));
    ++size_;
  }

  void PopBack() {
    if (size_ > 0) {
      data_[size_ - 1].~T();
      --size_;
    }
  }

  Iterator begin() noexcept { // NOLINT
    return data_;
  }

  ConstIterator begin() const noexcept { // NOLINT
    return data_;
  }

  ConstIterator cbegin() const noexcept { // NOLINT
    return data_;
  }

  Iterator end() noexcept { // NOLINT
    return data_ + size_;
  }

  ConstIterator end() const noexcept { // NOLINT
    return data_ + size_;
  }

  ConstIterator cend() const noexcept { // NOLINT
    return data_ + size_;
  }

  using ReverseIterator = std::reverse_iterator<Iterator>;
  using ConstReverseIterator = std::reverse_iterator<ConstIterator>;

  ReverseIterator rbegin() noexcept { // NOLINT
    return ReverseIterator(end());
  }

  ConstReverseIterator rbegin() const noexcept { // NOLINT
    return ConstReverseIterator(end());
  }

  ConstReverseIterator crbegin() const noexcept { // NOLINT
    return ConstReverseIterator(cend());
  }

  ReverseIterator rend() noexcept { // NOLINT
    return ReverseIterator(begin());
  }

  ConstReverseIterator rend() const noexcept { // NOLINT
    return ConstReverseIterator(begin());
  }

  ConstReverseIterator crend() const noexcept { // NOLINT
    return ConstReverseIterator(cbegin());
  }

 private:
  SizeType size_;
  SizeType capacity_;
  T* data_;
};

template <typename T>
bool operator==(const Vector<T>& lhs, const Vector<T>& rhs) {
  return lhs.Size() == rhs.Size() && std::equal(lhs.begin(), lhs.end(), rhs.begin());
}

template <typename T>
bool operator!=(const Vector<T>& lhs, const Vector<T>& rhs) {
  return !(lhs == rhs);
}

template <typename T>
bool operator<(const Vector<T>& lhs, const Vector<T>& rhs) {
  return std::lexicographical_compare(lhs.begin(), lhs.end(), rhs.begin(), rhs.end());
}

template <typename T>
bool operator<=(const Vector<T>& lhs, const Vector<T>& rhs) {
  return !(rhs < lhs);
}

template <typename T>
bool operator>(const Vector<T>& lhs, const Vector<T>& rhs) {
  return rhs < lhs;
}

template <typename T>
bool operator>=(const Vector<T>& lhs, const Vector<T>& rhs) {
  return !(lhs < rhs);
}
