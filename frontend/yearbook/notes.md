However, sometimes you have to target the underlying DOM element. As an example, you may want to change the border of the Button. The Button component defines its own styles. CSS inheritance doesn't help. To workaround the problem, you can use the sx prop directly on the child if it is a MUI component.

```typescript 
-<Box sx={{ border: '1px dashed grey' }}>
-  <Button>Save</Button>
-</Box>
+<Button sx={{ border: '1px dashed grey' }}>Save</Button>
```
For non-MUI components, use the component prop.
```typescript 
-<Box sx={{ border: '1px dashed grey' }}>
-  <button>Save</button>
-</Box>
+<Box component="button" sx={{ border: '1px dashed grey' }}>Save</Box>
```

convert non_MUI components
```typescript 
import { styled } from '@mui/material/styles';

const Div = styled('div')``;
```

https://stackoverflow.com/questions/52653103/what-is-appbar-vs-toolbar

toobar vs appbar
app bar: stacking item
toolbar: inline

## abbreviation
xs = extra small screens (mobile phones)
sm = small screens (tablets)
md = medium screens (some desktops)
lg = large screens (remaining desktops)

## React.FC<> vs functional component
**React.FC<>** provides typechecking and autocomplete for static properties like displayName, propTypes, and defaultProps 
known issues with defaultProps
https://github.com/typescript-cheatsheets/react#you-may-not-need-defaultprops

1. Provides an implicit definition of children, even if your component doesn't need to have children. That might cause an error.
2. Doesn't support generics.
3. Doesn't work correctly with defaultProps.
https://github.com/facebook/create-react-app/pull/8177