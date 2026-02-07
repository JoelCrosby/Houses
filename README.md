# Create House API Exercise

My goal with this approach is ensure that each house style is completely decoupled from the others. 
My take-away from reading the rules of each house style is while each house style could be derived from a shared abstract base, they don't share enough interoperable properties between the styles to make coupling them outweigh the benefits that separating them gains us, with the big one being maintainability as bugs cannot propagate through each style while they are separate from each other. It also means adding new styles doesn't require us to potentially break functionality in existing styles.
