import React from 'react'
import LinearProgress from "@mui/joy/LinearProgress";
import { Box } from '@mui/joy'
interface ILoader {
    children: React.ReactNode,
    isLoading: boolean
}
const Loader: React.FC<ILoader> = ({children, isLoading}) => {
    return (
        <>
            {
                isLoading?
                    <Box
                        sx={{
                            display: 'flex',
                            justifyContent: 'center',
                            width: '100%',
                            height: '100%',
                        }}
                    >
                        <LinearProgress
                            variant={'plain'}
                            size={'sm'}
                            color={'success'}
                            sx={{
                                backgroundColor: 'none',
                                maxHeight: '70vh',
                                maxWidth: '20vw',
                            }}
                        />
                    </Box>
                    :
                    (
                        <>
                            {children}
                        </>
                    )
            }
        </>
    )
}
export default Loader
