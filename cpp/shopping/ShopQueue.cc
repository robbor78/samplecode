#include "ShopQueue.h"
#include "Customer.h"

ShopQueue::ShopQueue() : q() {

}

void ShopQueue::Add(TPtrCustomer customer) {
  mtx.lock();
  q.push(customer);
  mtx.unlock();
}

TQueue::size_type ShopQueue::GetLength() {
  return q.size();
}

TPtrCustomer ShopQueue::Process() {
  TPtrCustomer c;
  mtx.lock();
  if (q.empty()) {
    c= TPtrCustomer();
  } else {
    c = q.front();
    q.pop();
  }
  mtx.unlock();
  return c;
}

ShopQueue::~ShopQueue() {
  TQueue empty;
  swap(q, empty);
}
