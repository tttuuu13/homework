#pragma once

template<typename T>
class UniquePtr {
 private:
  T *ptr_;
 public:
  UniquePtr() {
    ptr_ = nullptr;
  }
  explicit UniquePtr(T *ptr) : ptr_(ptr) {
    ptr = nullptr;
  };
  UniquePtr(UniquePtr<T> &&other) noexcept {
    delete ptr_;
    ptr_ = other.ptr_;
    other.ptr_ = nullptr;
  }

  UniquePtr<T> &operator=(UniquePtr<T> &&other) noexcept {
    delete ptr_;
    ptr_ = other.ptr_;
    other.ptr_ = nullptr;
    return *this;
  }

  UniquePtr(const UniquePtr<T> &) = delete;
  UniquePtr<T> &operator=(const UniquePtr<T> &) = delete;

  ~UniquePtr() {
    delete ptr_;
  }

  T &operator*() const {
    return *ptr_;
  }

  T *operator->() const {
    return ptr_;
  }

  explicit operator bool() const {
    return ptr_ != nullptr;
  }

  T *Release() {
    T *temp = ptr_;
    ptr_ = nullptr;
    return temp;
  }

  void Reset(T *ptr = nullptr) {
    delete ptr_;
    ptr_ = ptr;
  }

  void Swap(UniquePtr<T> &other) {
    std::swap(ptr_, other.ptr_);
  }

  T *Get() const {
    return ptr_;
  }
};