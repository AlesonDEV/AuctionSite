export {}

declare global {
    interface NextProps {
        params: {
            [key: string]: number | string
        },
        queryParams: {
            [key: string]: any
        }
    }
}