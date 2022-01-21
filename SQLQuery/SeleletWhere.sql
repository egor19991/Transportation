select R.LoadDensity, O.ShippingAddress, O.DeliveryAddress
from Rate R
left join Orders O ON O.IDRate = R.IDRate
Group BY rollup (R.LoadDensity, O.ShippingAddress, O.DeliveryAddress)