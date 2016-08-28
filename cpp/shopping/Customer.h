#ifndef _CUSTOMER_H_
#define _CUSTOMER_H_

#include <ostream>

class Customer {

public:
Customer() : numItems(0) {}

  int GetNumItems() const {return numItems;}
  void SetNumItems(int numItems) {this->numItems = numItems;}

private:
  int numItems;
};

 inline std::ostream& operator<<(std::ostream &strm, const Customer &c) {
  return strm << "Customer with " << c.GetNumItems()  << " item(s).";
}

#endif
