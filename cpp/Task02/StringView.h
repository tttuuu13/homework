#ifndef TASK02__STRINGVIEW_H_
#define TASK02__STRINGVIEW_H_
#include <iostream>

class StringView {
  StringView();

  StringView(const char* string); // NOLINT

  StringView(const char* string, size_t size);

  char& operator[](size_t index);

  char const At(size_t index);

  char const Front();

  char const Back();

  size_t Size();

  size_t Length();

  bool Empty();

  char* Data();

  void Swap(StringView&);

  void RemovePrefix(size_t prefix_size);

  void RemoveSuffix(size_t suffix_size);


};

#endif //TASK02__STRINGVIEW_H_
