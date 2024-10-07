#pragma once
template<typename T>
struct ControlBlock {
  T *ptr;
  int count = 0;
  explicit ControlBlock(T *object_pointer) : ptr(object_pointer) {
    if (ptr != nullptr) {
      count = 1;
    }
  };
  void Add() {
    count++;
  }
  void Remove() {
    if (count == 0) {
      delete ptr;
    } else {
      count--;
    }
  }
  ~ControlBlock() {
    if (count == 0) {
      delete ptr;
    } else {
      count = 0;
      ptr = nullptr;
    }
  }
};

template<typename T>
class SharedPtr {
 public:
  SharedPtr() : cb_(new ControlBlock<T>(nullptr)) {};
  explicit SharedPtr(T *ptr) : cb_(new ControlBlock<T>(ptr)) {};
  SharedPtr(const SharedPtr<T> &other) {
    cb_ = other.cb_;
    cb_->Add();
  }
  SharedPtr<T> &operator=(const SharedPtr<T> &other) {
    if (this != &other) {
      cb_ = other.cb_;
      cb_->Add();
    }
    return *this;
  }
  SharedPtr(SharedPtr<T> &&other) noexcept {
    cb_ = std::move(other.cb_);
    cb_->Add();
    other.cb_ = nullptr;
  }
  SharedPtr<T> &operator=(SharedPtr<T> &&other) noexcept {
    if (this != &other) {
      cb_ = std::move(other.cb_);
      other.cb_ = nullptr;
    }
    return *this;
  }
  void Reset(T *ptr = nullptr) {
    cb_->Remove();
    delete cb_;
    cb_ = new ControlBlock<T>(ptr);
  }
  void Swap(SharedPtr<T> &other) {
    if (this != &other) {
      ControlBlock<T> *tmp = cb_;
      cb_ = other.cb_;
      other.cb_ = tmp;
    }
  }
  T *Get() const {
    return (*cb_).ptr;
  }
  int UseCount() const {
    return cb_->count;
  }

  const T &operator*() const {
    return *Get();
  }
  T &operator*() {
    return *Get();
  }

  const SharedPtr<T> *operator->() const {
    return Get();
  }
  SharedPtr<T> *operator->() {
    return this;
  }
  explicit operator bool() const {
    return cb_->ptr != nullptr;
  }

 private:
  ControlBlock<T> *cb_;
};