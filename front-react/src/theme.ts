
import { extendTheme } from '@mui/joy/styles';


declare module '@mui/joy/styles' {
    // No custom tokens found, you can skip the theme augmentation.
}


const theme = extendTheme({
    "colorSchemes": {
        "light": {
            "palette": {
                "primary": {
                    "50": "#f0fdf4",
                    "100": "#dcfce7",
                    "200": "#bbf7d0",
                    "300": "#86efac",
                    "400": "#4ade80",
                    "500": "#22c55e",
                    "600": "#16a34a",
                    "700": "#15803d",
                    "800": "#166534",
                    "900": "#14532d"
                }
            }
        },
        "dark": {
            "palette": {}
        }
    }
})

export default theme;